using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;

public class SceneManager
{
    private static SceneManager _instance;
    public static SceneManager Instance {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneManager();
            }

            return _instance;
        }
    }
    private SceneManager() {}
    
    public Scene CurrentScene;
    public GraphicsDevice GraphicsDevice;
    private List<Scene> ScenesList = new List<Scene>();
    private int IndexOfScene = 0;
    public Game1 Game1;
    public ContentManager Manager;
    public Viewport Viewport;
    public void AwakeManager()
    {
        MakeScenes();
        
        if (ScenesList.Count <= 0)
            throw new Exception("No scenes in the ScenesList");
        CurrentScene = ScenesList[IndexOfScene];
    }
    public void LoadAllScenes()
    {
        foreach (Scene scene in ScenesList)
        {
            scene.AwakeScene();
            scene.LoadScene();
        }
    }
    public void UpdateManager(GameTime pGameTime) => CurrentScene.UpdateScene(pGameTime);
    public void DrawManager(SpriteBatch pSpriteBatch) => CurrentScene.DrawScene(pSpriteBatch);
    private void MakeScenes()
    {
        var scene01 = new MenuScene();
        var scene02 = new Opdracht02Scene();
        ScenesList.Add(scene01);
        ScenesList.Add(scene02);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pTargetScene">New instance of the wanted scene</param>
    public void SwapScene(Scene pTargetScene)
    {
        foreach (Scene scene in ScenesList)
        {
            Console.WriteLine(scene);
            if (scene.GetType() != pTargetScene.GetType()) continue;
            CurrentScene = scene;
        }
    }
}