using Godot;
using System;

public partial class Intro : Control
{
	private int _frames;
	private void _on_start_finished()
	{
		GetNode<AudioStreamPlayer>("Loop").Play();
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		_frames += 1;
		
		if (_frames > 720)
		{
			GetTree().ChangeSceneToFile("res://Assets/main.tscn");
		}
	}
}
