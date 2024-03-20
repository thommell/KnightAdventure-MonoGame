using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;

public class PlayButton : Button
{
    public PlayButton(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture)
    {
    }
    protected override void OnClick()
    {
        Console.WriteLine("");
    }
}