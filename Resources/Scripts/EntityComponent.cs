using Godot;
using System;

public partial class EntityComponent : Node
{
	[Export] public float speed = 5f;
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}
