using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;

public static class SceneManager
{
    public static Scene CurrentScene;
    public static GraphicsDevice GraphicsDevice;
    public static List<Scene> ScenesList = new List<Scene>();
    public static int IndexOfScene = 0;
    public static Game1 Game1;
    public static ContentManager Manager;
    public static Viewport Viewport;
    public static void SwapScene() {}
    public static void AwakeManager()
    {
        MakeScenes();
        if (ScenesList.Count <= 0)
            throw new Exception("No scenes in the ScenesList");
        CurrentScene = ScenesList[IndexOfScene];
        CurrentScene.AwakeScene();
    }
    public static void LoadManager() => CurrentScene.LoadScene();
    public static void UpdateManager(GameTime pGameTime) => CurrentScene.UpdateScene(pGameTime);
    public static void DrawManager(SpriteBatch pSpriteBatch) => CurrentScene.DrawScene(pSpriteBatch);
    private static void MakeScenes()
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
    public static void SwapScene(Scene pTargetScene)
    {
        foreach (Scene scene in ScenesList)
        {
            if (scene == pTargetScene) continue;
            CurrentScene = scene;
        }
    }
}