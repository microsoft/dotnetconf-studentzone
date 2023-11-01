using Godot;

namespace GodotPaddle.Game;

/// <summary>
/// This class is attached to the 'Node2D' root node of the Main Scene.
/// It was used as a demonstration of breakpoints and debugging output during the session.
/// It's not really needed for the game to function currently, but will be used in the follow-on .NET Conf talk (see Readme).
/// </summary>
public partial class Main : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Game Loaded");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
