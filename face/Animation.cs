using Godot;
using System;

public partial class Animation : AnimationPlayer
{
    [Signal]
    public delegate void FaceDoneEventHandler();

    private bool hasPlayed;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hasPlayed = false;
    }

    public override void _Process(double delta)
    {
        if (hasPlayed && !IsPlaying())
        {
            var global = (Global)GetNode("/root/Global");
            global.GotoScene("res://stage.tscn");
        }

        if (!hasPlayed && !IsPlaying())
        {
            hasPlayed = true;
            Play("awake");
        }
    }
}
