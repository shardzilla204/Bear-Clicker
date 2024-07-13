using Godot;
using System;

public partial class Bear : Sprite2D
{
	[Export] public Area2D bodyArea;
	[Export] public Area2D collectionArea;

	public override void _Ready()
	{
		collectionArea.AreaEntered += (Area2D area) => TestForHoneycomb(area);
		Loop();
	}

	public override void _Process(double delta)
	{
		
	}

	public async void Loop()
	{
		while(true)
		{
			await ToSignal(GetTree().CreateTimer(1f), SceneTreeTimer.SignalName.Timeout);
			TweenBear();
		}
	}

	public void TestForHoneycomb(Area2D area)
	{
		GD.Print(area.GetParent().GetType());
		if (area.GetParent().GetType() == typeof(Honeycomb))
		{
			GD.Print("Honeycomb detected");
		}
	}
	
	public void TweenBear()
	{
		float speed = 0.5f;
		Tween tween = CreateTween().SetParallel(true).SetTrans(Tween.TransitionType.Quad);
		tween.TweenProperty(this, "position", SetPosition(), speed);
	}

	public Vector2 SetPosition()
	{
		Vector2 position = GetPosition();
		while(IsInWindow(position))
		{
			position = GetPosition();
		}
		return position;
	}

	public Vector2 GetPosition()
	{
		RandomNumberGenerator random = new RandomNumberGenerator();
		float angle = random.RandfRange(0, 2 * Mathf.Pi);
		float distance = random.RandfRange(150, 300);
		Vector2 position = Position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

		return position;
	}

	public bool IsInWindow(Vector2 position)
	{
		Vector2I windowSize = GetWindow().Size;
		bool inWindow = true;
		if (position.X < 0) return inWindow;
		if (position.X > windowSize.X) return inWindow;
		if (position.Y < 0) return inWindow;
		if (position.Y > windowSize.Y) return inWindow;
		return !inWindow;
	}
}
