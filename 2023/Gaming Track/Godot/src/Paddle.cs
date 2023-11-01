using Godot;

namespace GodotPaddle.Game;

/// <summary>
/// This class is attached to the 'CharacterBody2D' root node of the Paddle Scene.
/// It represents an instance of a Paddle that can be controlled by us.
/// 
/// It was initially created with the built-in Godot template for the CharacterBody2D node.
/// 
/// In a final version of this type of project, you'd want to have some configuration
/// and code to differentiate between one or two player's controls or a computer to play against.
/// </summary>
public partial class Paddle : CharacterBody2D
{
	// Represents the speed the paddle will travel when input is received.
	public const float Speed = 300.0f;

	// The _PhysicsProcess method is called continually by the engine at a fixed rate, 
	// it's an important place to do any manipulation of physics based objects.
	// Otherwise, the physics engine may not react as expected, especially if you manipulate properties like position/velocity elsewhere.
	// See: https://docs.godotengine.org/en/stable/tutorials/scripting/idle_and_physics_processing.html
	public override void _PhysicsProcess(double delta)
	{
		// It is recommended for performance to assign Godot values to a local variable, 
		// especially if you plan to manipulate them with many calculations in your method.
		// See: https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_basics.html#common-pitfalls
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		// See: https://docs.godotengine.org/en/stable/getting_started/first_3d_game/02.player_input.html#creating-input-actions
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			// We're using the Y axis to move up/down only
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			// This next line is so if we're not providing input then we slowdown/stop, 
			// but since our Speed is high and we don't factor in time with (delta)
			// this effect is negligible and has the same effect if we set it to 0 directly.
			// TODO: Try commenting out this line and see what happens! ;)
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		// Here we're just assigning back our manipulated value to the Paddle, see the initial comment in this method.
		Velocity = velocity;
		
		// MoveAndSlide performs 'magic' by the physics engine and handles all the collisions our player-moved paddle may have with
		// other physics objects, like the Ball. Note though, that this default method and script was setup for a 2D platforming game
		// so there are some unintended consequences for using this directly. We saw this at the very end of the session.
		// We should use MoveAndCollide instead, see https://docs.godotengine.org/en/stable/tutorials/physics/using_character_body_2d.html
		MoveAndSlide();

		// To see the difference, you can comment out MoveAndSlide above and try this MoveAndCollide code instead:
		/*var collision = MoveAndCollide(velocity * (float)delta);
		// See if we have a collision and if it was with the Ball
        if (collision != null && collision.GetCollider() is Ball ball)
        {
			// If we have a collision we're going to change the Ball's velocity to reflect across the Normal of the collision
			// We could also add a bit more magnitude here to give it more oomph every hit
			// We could also add a bit of a random rotation to make it less predictable, lots of creative options.
			ball.LinearVelocity = ball.LinearVelocity.Bounce(collision.GetNormal());
		}*/
	}
}
