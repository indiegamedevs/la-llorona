using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public int RunSpeed = 100;
    [Export]
    public int JumpSpeed = -500;
    [Export]
    public int Gravity = 1200;

    private Vector2 _screenSize;
    private Vector2 _velocity = new Vector2();
    private bool _jumping = false;
    private bool _lookingRight = true;

    public bool LookingRight
    {
        get
        {
            return _lookingRight;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _screenSize = DisplayServer.ScreenGetSize();
    }

    public void GetInput()
    {
        _velocity.X = 0;

        if (Input.IsActionPressed("ui_select") && IsOnFloor())
        {
            _jumping = true;
            _velocity.Y = JumpSpeed;
        }

        if (Input.IsActionPressed("ui_right"))
        {
            _velocity.X += RunSpeed;
        }
        if (Input.IsActionPressed("ui_left"))
        {
            _velocity.X -= RunSpeed;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        if (!IsOnFloor())
        {
            _velocity.Y += Gravity * (float)delta;
        }
        if (_jumping && IsOnFloor())
        {
            _jumping = false;
        }
        var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        if (_velocity.X != 0)
        {
            animatedSprite.Play();
            if (_velocity.X < 0)
            {
                animatedSprite.FlipH = true;
                _lookingRight = false;
                GetParent<Stage>().MoveBackgroundLeft();
            }
            else
            {
                animatedSprite.FlipH = false;
                _lookingRight = true;
                GetParent<Stage>().MoveBackgroundRight();
            }
        }
        else
        {
            animatedSprite.Stop();
        }
        Velocity = _velocity;
        UpDirection = new Vector2(0, -1);
        var collided = MoveAndSlide();

        for (var i = 0; i < GetSlideCollisionCount(); i++)
        {
            var collision = GetSlideCollision(i);
            var node = (Godot.Node2D)collision.GetCollider();

            if (node.Name == "la_llorona" || node.Name == "bottom")
            {
                var global = (Global)GetNode("/root/Global");
                global.GotoScene("res://face/face.tscn");
            }
        }

        GetParent<Stage>().MoveCamera(Position);
    }

    public void OnPlayerBodyEntered(Godot.GodotObject body)
    {
        var global = (Global)GetNode("/root/Global");
        global.GotoScene("res://face/face.tscn");
    }
}
