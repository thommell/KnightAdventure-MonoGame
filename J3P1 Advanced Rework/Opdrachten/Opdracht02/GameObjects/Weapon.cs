using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;

public class Weapon : Interactable
{
    public Weapon(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public override void Interact(Player pPlayer)
    {
        pPlayer.HasWeapon = true;
        SceneManager.CurrentScene.RemoveObject(this);
    }
}