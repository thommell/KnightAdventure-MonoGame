using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;

public class Shield : Interactable
{
    public Shield(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public override void Interact(Player pPlayer)
    {
        pPlayer.HasShield = true;
        SceneManager.Instance.CurrentScene.RemoveObject(this);
    }
}