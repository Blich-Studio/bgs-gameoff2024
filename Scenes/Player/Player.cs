using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public bool MoveOnX {get; set; } = true;
    [Export] public int Speed { get; set; } = 100;
    [Export] private AnimationPlayer animationPlayer;
    [Export] Sprite2D spriteNode;


    public void GetInput()
    {
        Vector2 inputDirection = Vector2.Zero;
        
        if (MoveOnX)
        {
            inputDirection.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        } else {
            inputDirection.Y = Input.GetActionStrength("move_up") - Input.GetActionStrength("move_down");
        }

        Velocity = inputDirection.Normalized() * Speed;

        if (inputDirection == Vector2.Zero) {
            animationPlayer.Play("Idle");
        } else {
            animationPlayer.Play("Walking");
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
        Flip();
    }

    public override void _Ready()
    {
        animationPlayer.Play("Idle");
    }

    private void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return; }
        bool isMovingLeft = Velocity.X < 0;
        spriteNode.FlipH = isMovingLeft;
    }
}
