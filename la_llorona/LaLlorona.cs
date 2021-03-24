using Godot;
using System;

public class LaLlorona : KinematicBody2D
{
	[Export]
	public int RunSpeed = 95;
	
	public bool StartSpooking = true;

	Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetParent().GetNode<Player>("player");

	}

	public override void _PhysicsProcess(float delta)
	{  
		if(StartSpooking) {
		var velocity = Position.DirectionTo(player.Position) * RunSpeed;
		var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

		var collide = MoveAndCollide(velocity * delta);
		if (collide != null)
		{
			var node = (Godot.Node2D)collide.Collider;
			if (node.Name == "player")
			{
				var global = (Global)GetNode("/root/Global");
				global.GotoScene("res://face/face.tscn");
			}
		}

			if (velocity.x > 0)
		{
			if (player.LookingRight)
			{
				velocity = MoveAndSlide(velocity);
				animatedSprite.FlipH = velocity.x < 0;
			}
			else
			{
				velocity = Vector2.Zero;
				velocity = MoveAndSlide(velocity);
				animatedSprite.FlipH = true;
			}
		}
		else if (velocity.x < 0)
		{
			if (!player.LookingRight)
			{
				velocity = MoveAndSlide(velocity);
				animatedSprite.FlipH = velocity.x < 0;
			}
			else
			{
				velocity = Vector2.Zero;
				velocity = MoveAndSlide(velocity);
				animatedSprite.FlipH = false;
			}
		}
		}
	}
}
