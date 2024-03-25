using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.Scenes;
public class MenuScene : Scene
{
    private Texture2D _menuTexture;
    public override void LoadScene()
    {
        float padding = 10f;
        _menuTexture = SceneManager.Instance.Manager.Load<Texture2D>("menu");
        Texture2D buttonTexture = SceneManager.Instance.Manager.Load<Texture2D>("UI_Tile_128x64");
        
        var playButton = new PlayButton(new Vector2(WindowWidth / 4, WindowHeight / 2), buttonTexture, "PLAY", new Opdracht02Scene());
        var quitButton = new QuitButton(new Vector2(playButton.Position.X, playButton.Position.Y + buttonTexture.Height + padding), buttonTexture, "QUIT");
        
        GameObjects.Add(playButton);
        GameObjects.Add(quitButton);
        base.LoadScene();
    }
    public override void DrawScene(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(_menuTexture, Vector2.Zero, Color.White);
        base.DrawScene(pSpriteBatch);
    }
}