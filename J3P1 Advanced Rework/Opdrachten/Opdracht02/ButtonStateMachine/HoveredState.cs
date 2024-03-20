using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;

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