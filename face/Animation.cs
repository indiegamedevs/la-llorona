using Godot;
using System;

public class Animation : AnimationPlayer
{
	[Signal]
	public delegate void FaceDone();
	
	private bool hasPlayed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hasPlayed = false;
	}

	public override void _Process(float delta)
	{
		if (hasPlayed && !IsPlaying())
		{
			EmitSignal(nameof(FaceDone));
		}

		if (!hasPlayed && !IsPlaying())
		{
			hasPlayed = true;
			Play("awake");
		}
	}
}
