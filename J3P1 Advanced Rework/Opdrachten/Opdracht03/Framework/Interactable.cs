#region Libraries

using J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
public abstract class Interactable : GameObject
{
    protected Interactable(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public abstract void Interact(Player pPlayer);
}