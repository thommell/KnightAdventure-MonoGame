using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using Color = Microsoft.Xna.Framework.Color;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.ButtonStateMachine;

public class HoveredState : IButtonState
{
    public HoveredState(Button pButton, Color pColor)
    {
        Button = pButton;
        Color = pColor;
    }
    public void UpdateState()
    {
        Button.Color = Color;
        Console.WriteLine(Button.Color);
    }
    public Color Color { get; set;}
    public Button Button { get; set; }
}