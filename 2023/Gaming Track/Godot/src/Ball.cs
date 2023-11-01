using Godot;
using System;

public partial class Ball : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ApplyImpulse(Vector2.Up.Rotated(GD.Randf() * 2 * Mathf.Pi) * 300f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
