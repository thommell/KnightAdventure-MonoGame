using J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
public class Gate : Interactable
{
    public Gate(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public override void Interact(Player pPlayer) => SceneManager.Game1.Exit();
}