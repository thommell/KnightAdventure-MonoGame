using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;

public abstract class Humanoid : GameObject, IHealth
{
    private int _health;
    private int _strength;
    private bool _displayHealth = true;
    private readonly Vector2 _textDimensions = new();

    public int Health
    {
        get => _health;
        set => _health = value;
    }
    protected int Strength
    {
        get => _strength;
        set => _strength = value;
    }
    protected Humanoid(Vector2 pPosition, Texture2D pTexture, int pHealth, int pStrength) : base(pPosition, pTexture)
    {
        _health = pHealth;
        _strength = pStrength;
        
        _textDimensions.X = Texture.Width / 2f - SceneManager.Instance.Font.MeasureString(_health.ToString()).X / 2;
        _textDimensions.Y = Texture.Height / 2f - SceneManager.Instance.Font.MeasureString(_health.ToString()).Y / 2;
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        CheckCollision();
        Movement(pGameTime);
        base.UpdateObject(pGameTime);
    }
    public override void DrawObject(SpriteBatch pSpriteBatch)
    {
        base.DrawObject(pSpriteBatch);
        if (!_displayHealth) return;
       pSpriteBatch.DrawString(SceneManager.Instance.Font, _health.ToString(),
           new Vector2(Position.X + _textDimensions.X, Position.Y - _textDimensions.Y),
           Color.White, Rotation, Origin, Vector2.One,
           SpriteEffects.None, Layer);
    }
    // private void CheckCollision()
    // {
    //     List<GameObject> objects = SceneManager.Instance.CurrentScene.GameObjects;
    //     for (int i = objects.Count - 1; i >= 0; i--)
    //     {
    //         // O/n^2 collision check fix ?
    //         // bug fix for trying to get a (potential) iteration out of range
    //         if (i > objects.Count - 1) return;
    //         // continue the loop to check if the object isn't checking itself
    //         if (objects[i] == this) continue;
    //         // continue the loop if there is no collision
    //         if (!objects[i].Rectangle.Intersects(Rectangle)) continue;
    //         OnCollision(objects[i]);
    //     }
    // }
    private void CheckCollision()
    {
        int parentIndex = 0;
        List<GameObject> objects = SceneManager.Instance.CurrentScene.GameObjects;
        for (parentIndex = 0; parentIndex <= objects.Count; parentIndex++)
        {
            int childIndex = 0;
            for (childIndex = 1 + parentIndex; childIndex <= objects.Count - 1; childIndex++)
            {
                if (objects[childIndex].Rectangle.Intersects(Rectangle))
                    OnCollision(objects[childIndex]);
            }
        }
    }
    protected abstract void Movement(GameTime pGameTime);
    /// <summary>
    /// This method will send the collided GameObject.
    /// </summary>
    /// <param name="collision">The GameObject that has collided.</param>
    protected virtual void OnCollision(GameObject collision) {}
    public abstract void Die();
    public virtual void TakeDamage(int pDamage)
    {
        Health -= pDamage;
        if (Health > 0) return;
        if (Health <= 0) Die();
    }
}