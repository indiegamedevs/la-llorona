using Godot;
using System;

public class Face : Sprite
{
	private Sprite eyelids;
	private Vector2 endPosition = new Vector2(0, -260);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		eyelids = GetNode<Sprite>("eyelids");
		eyelids.Position = new Vector2(0, 0);
	}

	public override void _Process(float delta)
	{
	}
}
