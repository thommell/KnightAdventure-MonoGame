using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;

public class QuitButton : Button
{
    public QuitButton(Vector2 pPosition, Texture2D pTexture, string pButtonText) : base(pPosition, pTexture, pButtonText) {}
    protected override void OnClick()
    {
        SceneManager.Instance.Game1.Exit();
    }
}