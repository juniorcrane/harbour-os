using Godot;
using System;
using System.Diagnostics;

public partial class Ui : RichTextLabel
{
	private int _option = 1;
	private bool _pressed = false;
	private bool _pressedAccept = false;
	private int _menu = 1;
	
	private bool _swappedFrom1 = false;
	private bool _swappedFrom2 = false;
	
	private string[] _games = new string[5];
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		using var file = FileAccess.Open(OS.GetExecutablePath().GetBaseDir().PathJoin("game.txt"), FileAccess.ModeFlags.Read);
		_games = file.GetAsText().Split(", ");
		
		if (_menu == 1)
		{
			if (_option == 1)
			{
				Text = "Main Menu:[br][br]-> Find Games[br]Shut Down";
			}
			
			if (_option == 2)
			{
				Text = "Main Menu:[br][br]Find Games[br]-> Shut Down";
			}
			
			if (_option < 1)
			{
				_option = 1;
			}
			
			if (_option > 2)
			{
				_option = 2;
			}
		}
		
		if (_menu == 2)
		{
			if (_option == 1)
			{
				Text = $"-> Back[br]{_games[0]}[br]{_games[1]}[br]{_games[2]}[br]{_games[3]}[br]{_games[4]}";
			}
			
			if (_option == 2)
			{
				Text = $"Back[br]-> {_games[0]}[br]{_games[1]}[br]{_games[2]}[br]{_games[3]}[br]{_games[4]}";
			}
			
			if (_option == 3)
			{
				Text = $"Back[br]{_games[0]}[br]-> {_games[1]}[br]{_games[2]}[br]{_games[3]}[br]{_games[4]}";
			}
			
			if (_option == 4)
			{
				Text = $"Back[br]{_games[0]}[br]{_games[1]}[br]-> {_games[2]}[br]{_games[3]}[br]{_games[4]}";
			}
			
			if (_option == 5)
			{
				Text = $"Back[br]{_games[0]}[br]{_games[1]}[br]{_games[2]}[br]-> {_games[3]}[br]{_games[4]}";
			}
			
			if (_option == 6)
			{
				Text = $"Back[br]{_games[0]}[br]{_games[1]}[br]{_games[2]}[br]{_games[3]}[br]-> {_games[4]}";
			}
			
			if (_option < 1)
			{
				_option = 1;
			}
			
			if (_option > 6)
			{
				_option = 6;
			}
		}
		
		if (Input.IsKeyPressed(Key.Down) == true)
		{
			if (_pressed == false)
			{
				GetNode<AudioStreamPlayer>("Move").Play();
				_option += 1;
				_pressed = true;
			}
		}
		
		if (Input.IsKeyPressed(Key.Up) == true)
		{
			if (_pressed == false)
			{
				GetNode<AudioStreamPlayer>("Move").Play();
				_option -= 1;
				_pressed = true;
			}
		}
		
		if ((Input.IsKeyPressed(Key.Up) == false) && (Input.IsKeyPressed(Key.Down) == false))
		{
			_pressed = false;
		}
		
		if (Input.IsKeyPressed(Key.Enter) == false)
		{
			_pressedAccept = false;
		}
		
		
		
		if (Input.IsKeyPressed(Key.Enter) == true)
		{
			if (_pressedAccept == false)
			{
				if (_menu == 1)
				{
					_pressedAccept = true;
					
					if (_option == 1)
					{
						GetNode<AudioStreamPlayer>("Accept").Play();
						Process.Start(OS.GetExecutablePath().GetBaseDir().PathJoin("listItch"));
						_menu = 2;
					}
					
					if (_option == 2)
					{
						GetTree().Quit();
					}
				}
			}
		}
		
		if (Input.IsKeyPressed(Key.Enter) == true)
		{
			if (_pressedAccept == false)
			{
				if (_menu == 2)
				{
					_pressedAccept = true;
					
					if (_option == 1)
					{
						GetNode<AudioStreamPlayer>("Cancel").Play();
						_menu = 1;
					}
					
					if (_option == 2)
					{
						GetNode<AudioStreamPlayer>("Accept").Play();
						Process.Start(OS.GetExecutablePath().GetBaseDir().PathJoin("launchItch"), _games[0]);
					}
					
					if (_option == 3)
					{
						
						Process.Start(OS.GetExecutablePath().GetBaseDir().PathJoin("launchItch"), _games[1]);
					}
					
					if (_option == 4)
					{
						Process.Start(OS.GetExecutablePath().GetBaseDir().PathJoin("launchItch"), _games[2]);
					}
					
					if (_option == 5)
					{
						Process.Start(OS.GetExecutablePath().GetBaseDir().PathJoin("launchItch"), _games[3]);
					}
					
					if (_option == 6)
					{
						Process.Start(OS.GetExecutablePath().GetBaseDir().PathJoin("launchItch"), _games[4]);
					}
				}
			}
		}
	}
}
