using Godot;
using System;

public class Camera : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void Move(Vector2 position)
	{
		Position = new Vector2(position.x -960, Position.y);
	}
}
