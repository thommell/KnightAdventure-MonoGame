using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;
public class Scene
{
   #region Variables
   
   private List<GameObject> _gameObjects = new List<GameObject>();
   
   #endregion
   #region Properties
   public List<GameObject> GameObjects
   {
      get => _gameObjects;
      protected set => _gameObjects = value;
   }
   #endregion
   public virtual void AwakeScene() {}
   public virtual void LoadScene()
   {
      for (int i = 0; i < GameObjects.Count; i++)
      {
         GameObjects[i].LoadObject();
      }
   }
   public virtual void UpdateScene(GameTime pGameTime)
   {
      for (int i = 0; i < GameObjects.Count; i++)
      {
         GameObjects[i].UpdateObject(pGameTime);
      }
   }
   public virtual void DrawScene(SpriteBatch pSpriteBatch)
   {
      for (int i = 0; i < GameObjects.Count; i++)
      {
         GameObjects[i].DrawObject(pSpriteBatch);
      }
   }
   public void RemoveObject() {}
}