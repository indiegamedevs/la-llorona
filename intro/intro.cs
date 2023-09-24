using Godot;
using System;

public partial class intro : Sprite2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }


    private void _on_Button_pressed()
    {
        var global = (Global)GetNode("/root/Global");
        global.GotoScene("res://face/face.tscn");
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}


