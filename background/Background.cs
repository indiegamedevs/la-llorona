using Godot;
using System;

public partial class Background : Godot.ParallaxBackground
{
    public void AnimateBackground(int offset)
    {
        this.ScrollOffset = new Vector2(ScrollOffset.X + offset, ScrollOffset.Y);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        //AnimateBackground();
    }
}
