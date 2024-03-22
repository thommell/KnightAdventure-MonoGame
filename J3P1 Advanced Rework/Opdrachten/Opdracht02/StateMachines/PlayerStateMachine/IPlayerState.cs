using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.PlayerStateMachine;

public interface IPlayerState
{
    public Texture2D PlayerTexture { get; }
    public Player Player { get; }
    public void OnStateEnter();
}