using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;

public class Enemy : Humanoid
{
    private int _strength;
    public Enemy(Vector2 pPosition, Texture2D pTexture, int pHealth, int pStrength) : base(pPosition, pTexture, pHealth) => _strength = pStrength;
    protected override void Movement(GameTime pGameTime)
    {
        //throw new System.NotImplementedException();
    }
    private void Attack(Player pPlayer)
    {
        Console.WriteLine("Enemy has attacked the player!!");
        pPlayer.TakeDamage(_strength);
    }
    protected override void OnCollision(GameObject collision)
    {
        if (collision is not Player player) return;
        Attack(player);
    }
    public override void Die()
    {
        SceneManager.Instance.CurrentScene.RemoveObject(this);
    }
}