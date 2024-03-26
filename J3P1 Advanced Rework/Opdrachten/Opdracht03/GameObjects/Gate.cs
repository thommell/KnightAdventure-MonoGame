using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
public class Gate : Interactable
{
    private readonly Scene _targetScene;
    public Gate(Vector2 pPosition, Texture2D pTexture, Scene pTargetScene) : base(pPosition, pTexture) =>
        _targetScene = pTargetScene;
    public override void Interact(Player pPlayer) => SceneManager.Instance.SwapScene(_targetScene);
}