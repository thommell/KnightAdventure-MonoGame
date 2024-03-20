using J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Scenes;
public class MenuScene : Scene
{
    public override void LoadScene()
    {
        Texture2D buttonTexture = SceneManager.Manager.Load<Texture2D>("UI_Tile_128x64");

        var button = new PlayButton(new Vector2(WindowWidth / 2, WindowHeight / 2), buttonTexture);
        
        GameObjects.Add(button);
        base.LoadScene();
    }
}