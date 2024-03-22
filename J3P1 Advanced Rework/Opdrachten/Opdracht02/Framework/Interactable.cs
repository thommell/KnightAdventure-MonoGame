#region Libraries

using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
public abstract class Interactable : GameObject
{
    protected Interactable(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public abstract void Interact(Player pPlayer);
}