using Godot;
using System;

public partial class Intro : Node2D
{
    [Export] private AnimationPlayer rainAnimationPlayer;
    [Export] private AnimationPlayer lightAnimationPlayer;
    public override void _Ready()
    {
        rainAnimationPlayer.Play("rain");
        lightAnimationPlayer.Play("blinking");
    }
}
