using Godot;
using System;

public partial class LaLlorona : CharacterBody2D
{
    [Export]
    public int RunSpeed = 95;

    public bool StartSpooking = true;

    Player player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetParent().GetNode<Player>("player");
        UpDirection = new Vector2(0, -1);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (StartSpooking)
        {
            var velocity = Position.DirectionTo(player.Position) * RunSpeed;
            var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

            if (velocity.X > 0)
            {
                if (player.LookingRight)
                {
                    Velocity = velocity;
                    MoveAndCheckForPlayerCollision(delta);
                    animatedSprite.FlipH = velocity.X < 0;
                }
                else
                {
                    velocity = Vector2.Zero;
                    Velocity = velocity;
                    MoveAndSlide();
                    animatedSprite.FlipH = true;
                }
            }
            else if (velocity.X < 0)
            {
                if (!player.LookingRight)
                {
                    Velocity = velocity;
                    MoveAndCheckForPlayerCollision(delta);
                    animatedSprite.FlipH = velocity.X < 0;
                }
                else
                {
                    velocity = Vector2.Zero;
                    Velocity = velocity;
                    MoveAndSlide();
                    animatedSprite.FlipH = false;
                }
            }
        }
    }

    private void MoveAndCheckForPlayerCollision(double delta)
    {
        var collided = MoveAndSlide();

        if (collided)
        {
            for (var i = 0; i < GetSlideCollisionCount(); i++)
            {
                var collision = GetSlideCollision(i);
                var node = (Godot.Node2D)collision.GetCollider();

                if (node.Name == "player")
                {
                    var global = (Global)GetNode("/root/Global");
                    global.GotoScene("res://face/face.tscn");
                }
            }
        }
    }
}
