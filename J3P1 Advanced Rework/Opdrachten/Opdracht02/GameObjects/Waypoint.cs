using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;

public class Waypoint : GameObject
{
    private Random _random = new Random();
    public Waypoint(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture) {}
    public Vector2 GetRandomPosition(Vector2 pos1, Vector2 pos2)
    {
        float _pos1 = _random.Next((int)pos1.X, (int)pos2.X + 1);
        float _pos2 = _random.Next((int)pos1.Y, (int)pos2.Y + 1);
        return new Vector2(_pos1, _pos2);
    }
}