#region Libraries

using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;
public abstract class Interactable : GameObject
{
    internal Player _playerInstance;
    protected Interactable(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public override void LoadObject()
    {
        base.LoadObject();
        _playerInstance = GetPlayer();
    }
    private Player GetPlayer()
    {
        List<GameObject> objects = SceneManager.CurrentScene.GameObjects;
        Player localPlayer;
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            if (objects[i].GetType() != typeof(Player)) continue; 
            localPlayer = (Player)objects[i];
            return localPlayer;
        }
        return null;
    }
    public abstract void Interact(Player pPlayer);
}