using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;

public abstract class Humanoid : GameObject, IHealth
{
    private int _health;
    private int _strength;
    private bool displayHealth = true;
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
       pSpriteBatch.DrawString(SceneManager.Instance.Font, _health.ToString(),
           new Vector2(Position.X + _textDimensions.X, Position.Y - _textDimensions.Y),
           Color.White, Rotation, Origin, Vector2.One,
           SpriteEffects.None, Layer);
    }
    private void CheckCollision()
    {
        List<GameObject> objects = SceneManager.Instance.CurrentScene.GameObjects;
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            // continue back through the loop to check if its not colliding with itself
            if (objects[i] == this) continue;
            // continue back through the loop if there is no collision
            if (!objects[i].Rectangle.Intersects(Rectangle)) continue;
            OnCollision(objects[i]);
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