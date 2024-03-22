using System;
using System.Collections.Generic;
using System.Linq;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
public class SceneManager
{
    private static SceneManager _instance;
    public static SceneManager Instance { get { return _instance ??= new SceneManager(); } }
    private SceneManager() {}
    #region Properties
    public Scene CurrentScene { get; private set; }
    public GraphicsDevice GraphicsDevice { get; set; }
    private List<Scene> ScenesList { get; set; } = new List<Scene>();
    public ContentManager Manager { get; set; }
    public Viewport Viewport { get; set; }
    public SpriteFont Font { get; set; }
    public Game1 Game1 { get; set; }
    #endregion
   
    public void AwakeManager()
    {
        MakeScenes();
        if (ScenesList.Count <= 0)
            throw new Exception("No scenes in the ScenesList");
        var firstScene = ScenesList.First();
        CurrentScene = firstScene; 
    }
    public void LoadCurrentScene()
    {
        CurrentScene.AwakeScene();
        CurrentScene.LoadScene();
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
            LoadCurrentScene();
        }
    }
}