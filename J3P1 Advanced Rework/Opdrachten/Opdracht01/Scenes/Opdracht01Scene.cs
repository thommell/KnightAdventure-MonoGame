using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.Scenes;

public class Opdracht01Scene : Scene
{
    public override void LoadScene()
    {
        Texture2D playerTex = SceneManager.Manager.Load<Texture2D>("Knight");
        Texture2D shieldTex = SceneManager.Manager.Load<Texture2D>("Shield");
        Texture2D weaponTex = SceneManager.Manager.Load<Texture2D>("Weapon");
        Texture2D gateTex = SceneManager.Manager.Load<Texture2D>("Gate");

        #region Objects Creation

        var player = new Player(
            new Vector2(playerTex.Width, playerTex.Height),
            playerTex,
            250f
        );
        var shield = new Shield(
            new Vector2(
                WindowWidth / 2,
                WindowHeight / 4),
            shieldTex
        );
        var weapon = new Weapon(
            new Vector2(
                WindowWidth / 4,
                WindowHeight / 2),
            weaponTex);

        var gate = new Gate(
            new Vector2(
                WindowWidth / 1.25f,
                WindowHeight / 1.25f
                ),
                gateTex);

        #endregion
        GameObjects.Add(player);
        GameObjects.Add(shield);
        GameObjects.Add(weapon);
        GameObjects.Add(gate);
        base.LoadScene();
    }
}