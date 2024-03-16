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
        var player = new Player(new Vector2(0f, 0f), playerTex, 5f);
        
        GameObjects.Add(player);
        Console.WriteLine(GameObjects.Count);
        base.LoadScene();
    }
}