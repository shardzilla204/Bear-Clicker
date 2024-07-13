using Godot;

public partial class ClickComponent : Node
{
    [Signal] public delegate void ClickEventHandler();

    [Export] public Area2D area;
    private bool _isHovering = false;

    public override void _Ready()
    {
        area.MouseEntered += () => {_isHovering = true;};
        area.MouseExited += () => {_isHovering = false;};
    }

    public override void _Process(double delta)
    {
        if (!_isHovering) return;
        if (!Input.IsActionJustPressed("Click")) return;

        EmitSignal(SignalName.Click);
    }
}
