using Godot;
using System;

public partial class DemoLevel : Node2D
{
    [Export] private AnimationPlayer animationPlayer;
        public override void _Ready()
    {
        animationPlayer.Play("neon sign");
    }
}
