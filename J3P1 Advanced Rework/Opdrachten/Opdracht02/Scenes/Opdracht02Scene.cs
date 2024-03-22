using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Scenes;

public class Opdracht02Scene : Scene
{
    public override void LoadScene()
    {
        Texture2D playerTex = SceneManager.Instance.Manager.Load<Texture2D>("Knight");
        Texture2D shieldTex = SceneManager.Instance.Manager.Load<Texture2D>("Shield");
        Texture2D weaponTex = SceneManager.Instance.Manager.Load<Texture2D>("Weapon");
        Texture2D gateTex = SceneManager.Instance.Manager.Load<Texture2D>("Gate");
        Texture2D enemyTex = SceneManager.Instance.Manager.Load<Texture2D>("Enemy");

        #region Objects Creation

        var player = new Player(new Vector2(playerTex.Width, playerTex.Height), playerTex, 250f, 10);
        var shield = new Shield(new Vector2(WindowWidth / 2, WindowHeight / 4), shieldTex);
        var weapon = new Weapon(new Vector2(WindowWidth / 4, WindowHeight / 2), weaponTex);
        var gate = new Gate(new Vector2(WindowWidth / 1.25f, WindowHeight / 1.25f), gateTex, new MenuScene());
        var enemy1 = new Enemy(new Vector2(500, 200), enemyTex, 10, 5);

        #endregion
        
        GameObjects.Add(player);
        GameObjects.Add(shield);
        GameObjects.Add(weapon);
        GameObjects.Add(gate);
        GameObjects.Add(enemy1);
        base.LoadScene();
    }
}