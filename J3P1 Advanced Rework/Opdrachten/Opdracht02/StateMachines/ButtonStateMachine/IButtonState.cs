using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;
public interface IButtonState
{
    public void UpdateState();
    public Color Color { get; set; }
    public Button Button { get; set; }
}