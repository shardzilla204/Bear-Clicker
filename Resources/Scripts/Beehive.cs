using Godot;
using System;

public partial class Beehive : Sprite2D
{
	[Export] public ClickComponent clickComponent;
	[Export] public PackedScene honeycombScene;

	private int _score = 0;

	public override void _Ready()
	{
		clickComponent.Click += CreateHoneycomb;
	}

	public override void _Process(double delta)
	{

	}

	public void CreateHoneycomb()
	{
		Honeycomb honeycombNode = honeycombScene.Instantiate<Honeycomb>();
		GetParent().AddChild(honeycombNode);
		honeycombNode.Name = "Honeycomb";
		honeycombNode.Position = Position;
		honeycombNode.Scale = Vector2.Zero;
		honeycombNode.Rotation = CreateHoneycombRotation();
		
		TweenHoneycomb(honeycombNode);
	}

	public void TweenHoneycomb(Honeycomb honeycomb)
	{
		float speed = 0.5f;
		Tween tween = CreateTween().SetParallel(true).SetTrans(Tween.TransitionType.Quad);
		tween.TweenProperty(honeycomb, "position", CreateHoneycombPosition(honeycomb), speed);
		tween.TweenProperty(honeycomb, "scale", CreateHoneycombScale(), speed);
		tween.TweenProperty(honeycomb, "rotation", CreateHoneycombRotation(), speed);
	}

	public Vector2 CreateHoneycombPosition(Honeycomb honeycomb)
	{
		RandomNumberGenerator random = new RandomNumberGenerator();
		float angle = random.RandfRange(0, 2 * Mathf.Pi);
		float distance = random.RandfRange(150, 300);
		Vector2 position = honeycomb.Position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
		return position;
	}

	public Vector2 CreateHoneycombScale()
	{
		RandomNumberGenerator random = new RandomNumberGenerator();
		float scaleValue = random.RandfRange(0.25f, 0.5f);
		Vector2 scale = new Vector2(scaleValue, scaleValue);
		return scale;
	}

	public float CreateHoneycombRotation()
	{
		RandomNumberGenerator random = new RandomNumberGenerator();
		float rotation = Mathf.DegToRad(random.RandfRange(0, 360f));
		return rotation;
	}
}
