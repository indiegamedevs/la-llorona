using Godot;
using System;

public class player : Node2D
{
	[Export]
	public int Speed = 0;

	private Vector2 _screenSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screenSize = GetViewport().GetSize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var velocity = new Vector2();

		if (Input.IsActionPressed("ui_right"))
		{
			velocity.x += 1;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x -= 1;
		}

		if (Input.IsActionPressed("ui_down"))
		{
			velocity.y += 1;
		}

		if (Input.IsActionPressed("ui_up"))
		{
			velocity.y -= 1;
		}


		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}

		Position += velocity * delta;
		Position = new Vector2(
			Mathf.Clamp(Position.x, 0, _screenSize.x),
			Mathf.Clamp(Position.y, 0, _screenSize.y)
		);
	}
}
