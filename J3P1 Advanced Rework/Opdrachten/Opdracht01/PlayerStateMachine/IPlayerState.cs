using J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
using Microsoft.Xna.Framework.Graphics;
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.PlayerStateMachine;

public interface IPlayerState
{
    public Texture2D PlayerTexture { get; }
    public Player Player { get; }
    public void OnStateEnter();
}