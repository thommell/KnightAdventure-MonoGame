using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;

public class Interactable : GameObject
{
    //private Player _player;
    public Interactable(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture)
    {   
        
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        OnCollision();
        base.UpdateObject(pGameTime);
    }
    public void OnCollision()
    {
        List<GameObject> objects = SceneManager.CurrentScene.GameObjects;
        foreach (var obj in objects)
        {
            if (obj == this) continue;
            if (obj.Rectangle.Intersects(Rectangle))
            {
                Console.WriteLine(obj.Rectangle);
            }
        }   
    }
}