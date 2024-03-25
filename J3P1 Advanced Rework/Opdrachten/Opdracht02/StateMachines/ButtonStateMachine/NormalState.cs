using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;

public class NormalState : IButtonState
{
    public void UpdateState()
    {
        Button.Color = Color;
    }
    public Color Color { get; set; }
    public Button Button { get; set; }
    public NormalState(Button pButton, Color pColor)
    {
        Button = pButton;
        Color = pColor;
    }
}