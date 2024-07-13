using System;
using Godot;

public partial class Game : Node2D
{
	[Export] public Label scoreLabel;
	[Export] public Label honeycombLabel;
	[Export] public Button buyBearButton;
	[Export] public PackedScene bearScene;

	public static int score = 0;
	public static int costForBear = 45;
	public static int bears = 0;

	public override void _Ready()
	{
		buyBearButton.Pressed += CreateBear;
	}

	public override void _Process(double delta)
	{
		scoreLabel.Text = $"Score: {score}";
	}

	public static void UpdateScore(int amount)
	{
		score += amount;
	}

	public void BuyBear()
	{
		if (score < costForBear) return;

		score -= costForBear;
		costForBear = Mathf.RoundToInt(costForBear * 1.25f);
		CreateBear();
		bears++;
	}

	public void CreateBear()
	{
		Bear bearNode = bearScene.Instantiate<Bear>();
		bearNode.Position = new Vector2(640, 360);
		AddChild(bearNode);
	}
}
