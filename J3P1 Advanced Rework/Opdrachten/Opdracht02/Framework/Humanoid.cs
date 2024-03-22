using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;

public abstract class Humanoid : GameObject, IHealth
{
    private int _health;

    public int Health
    {
        get => _health;
        set => _health = value;
    }

    protected Humanoid(Vector2 pPosition, Texture2D pTexture, int pHealth) : base(pPosition, pTexture) => _health = pHealth;
    public override void UpdateObject(GameTime pGameTime)
    {
        CheckCollision();
        Movement(pGameTime);
        base.UpdateObject(pGameTime);
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