using Godot;
using System;

public partial class Honeycomb : Sprite2D
{
	[Export] public HoverComponent hoverComponent;

	public override void _Ready()
	{
		hoverComponent.Hover += CollectHoneycomb;
	}

	public override void _Process(double delta)
	{

	}

	public async void CollectHoneycomb()
	{
		await ToSignal(GetTree().CreateTimer(0.25f), SceneTreeTimer.SignalName.Timeout);
		Game.UpdateScore(1);
		QueueFree();
	}
}
