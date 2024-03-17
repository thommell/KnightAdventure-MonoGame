using J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.PlayerStateMachine;

public class PlayerWeaponShield : IPlayerState
{
    public PlayerWeaponShield(Player pPlayer, Texture2D pTexture)
    {
        Player = pPlayer;
        PlayerTexture = pTexture;
    }
    public Texture2D PlayerTexture { get; }
    public Player Player { get; }
    public void OnStateEnter() => Player.Texture = PlayerTexture;
}