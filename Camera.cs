using Godot;
using System;

public partial class Camera : Camera2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void Move(Vector2 position)
    {
        Position = new Vector2(position.X - 960, Position.Y);
    }
}
