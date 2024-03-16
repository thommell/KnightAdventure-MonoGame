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
        var player = new Player(
            new Vector2(0f, 0f),
            playerTex,
            250f
            );
        var shield = new Interactable(
            new Vector2(WindowWidth / 2,
                WindowHeight / 2),
            shieldTex
            );
        GameObjects.Add(player);
        GameObjects.Add(shield);
        base.LoadScene();
    }
}