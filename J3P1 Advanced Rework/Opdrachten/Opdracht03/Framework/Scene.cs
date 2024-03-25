using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
public class Scene
{
   #region Variables

   private float _windowWidth;
   private float _windowHeight;
   private List<GameObject> _gameObjects = new List<GameObject>();
   
   #endregion
   #region Properties

   public float WindowWidth
   {
      get => _windowWidth;
      set => _windowWidth = value;
   }

   public float WindowHeight
   {
      get => _windowHeight;
      set => _windowHeight = value;
   }
   public List<GameObject> GameObjects
   {
      get => _gameObjects;
      protected set => _gameObjects = value;
   }
   #endregion

   public virtual void AwakeScene()
   {
      WindowWidth = SceneManager.Instance.GraphicsDevice.Viewport.Width;
      WindowHeight = SceneManager.Instance.GraphicsDevice.Viewport.Height;
   }
   public virtual void LoadScene()
   {
      foreach (var gameObject in GameObjects)
      {
         gameObject.LoadObject();
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
   public void RemoveObject(GameObject pObj)
   {
      if (!GameObjects.Contains(pObj)) return;
      GameObjects.Remove(pObj);
   }
}