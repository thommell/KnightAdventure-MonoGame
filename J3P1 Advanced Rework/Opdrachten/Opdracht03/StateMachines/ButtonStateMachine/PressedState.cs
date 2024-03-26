using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.ButtonStateMachine;

public class PressedState : IButtonState
{
    public Color Color { get; set; }
    public Button Button { get; set; }
    public PressedState(Button pButton, Color pColor)
    {
        Button = pButton;
        Color = pColor;
    }
    public void StartState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        Button.Color = Color;
    }

   
}