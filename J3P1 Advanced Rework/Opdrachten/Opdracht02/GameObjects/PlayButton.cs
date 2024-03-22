using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;

public class PlayButton : Button
{
    private readonly Scene _targetScene;
    public PlayButton(Vector2 pPosition, Texture2D pTexture, string pButtonText, Scene pTargetScene) : base(pPosition, pTexture, pButtonText)
    {
        _targetScene = pTargetScene;
    }
    protected override void OnClick()
    {
        SceneManager.Instance.SwapScene(_targetScene);
    }
}