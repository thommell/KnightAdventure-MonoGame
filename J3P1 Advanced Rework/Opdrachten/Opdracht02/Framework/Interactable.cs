#region Libraries

using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
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
        List<GameObject> objects = SceneManager.Instance.CurrentScene.GameObjects;
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            if (objects[i] is not Player) continue; 
            var localPlayer = (Player)objects[i];
            return localPlayer;
        }
        return null;
    }
    public abstract void Interact(Player pPlayer);
}