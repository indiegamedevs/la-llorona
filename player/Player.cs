using Godot;
using System;

public class Player : KinematicBody2D
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
		get {
			return _lookingRight;
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screenSize = GetViewport().Size;
	}

	public void GetInput() {
		_velocity.x = 0;

		if(Input.IsActionPressed("ui_select") && IsOnFloor()) {
			_jumping = true;
			_velocity.y = JumpSpeed;
		}

		if (Input.IsActionPressed("ui_right")) {
			_velocity.x += RunSpeed;
		}
		if (Input.IsActionPressed("ui_left")) {
			_velocity.x -= RunSpeed;

		}
	}

	public override void _PhysicsProcess(float delta) {
		GetInput();
		_velocity.y += Gravity * delta;
		if(_jumping && IsOnFloor()) {
			_jumping = false;
		}
		var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		if(_velocity.x != 0) {
			animatedSprite.Play();
			if(_velocity.x < 0) {
				animatedSprite.FlipH = true;
				_lookingRight = false;
				GetParent<Stage>().MoveBackgroundLeft();
			} else {
				animatedSprite.FlipH = false;
				_lookingRight = true;
				GetParent<Stage>().MoveBackgroundRight();
			}
		} else {
			animatedSprite.Stop();
		}
		_velocity = MoveAndSlide(_velocity, new Vector2(0, -1));
		GetParent<Stage>().MoveCamera(Position);
	}
}
