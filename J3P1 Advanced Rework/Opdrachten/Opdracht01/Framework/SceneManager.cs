using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;

public static class SceneManager
{
    public static Scene CurrentScene;
    public static List<Scene> ScenesList = new List<Scene>();
    public static int IndexOfScene = 0;
    public static Game1 Game1;
    public static ContentManager Manager;
    public static void SwapScene() {}

    public static void AwakeManager()
    {
        MakeScenes();
        if (CurrentScene != null) return;
        CurrentScene = ScenesList[IndexOfScene];
        CurrentScene.AwakeScene();
    }
    public static void LoadManager() => CurrentScene.LoadScene();
    public static void UpdateManager(GameTime pGameTime) => CurrentScene.UpdateScene(pGameTime);
    public static void DrawManager(SpriteBatch pSpriteBatch) => CurrentScene.DrawScene(pSpriteBatch);

    private static void MakeScenes()
    {
        var scene01 = new Opdracht01Scene();
        
        ScenesList.Add(scene01);
    }

    // public static void DrawManager() => _currentScene.

}