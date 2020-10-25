using Godot;
using System;

public class Stage : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	private Background _bg;
	private Camera _camera;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_bg = GetNode<Background>("background");
		_camera = GetNode<Camera>("camera");
	}

	public void MoveBackgroundLeft() {
		_bg.AnimateBackground(1);
	}
	
	public void MoveBackgroundRight() {
		_bg.AnimateBackground(-1);
	}

	public void MoveCamera(Vector2 position)
	{
		_camera.Move(position);
	}
}
