using Godot;
using System;

public partial class Bgm : AudioStreamPlayer
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (GetWindow().HasFocus())
		{
			VolumeDb = -10;
		} else VolumeDb = -999;
	}
}
