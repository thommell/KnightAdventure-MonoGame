using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.EnemyStateMachine;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;

public class Enemy : Humanoid
{
    private List<Waypoint> _waypoints;
    private float _speed;
    private int index = 0;
    private StateMachineEnemy _stateMachineEnemy;


    public Enemy(Vector2 pPosition, Texture2D pTexture, int pHealth, int pStrength, int pSpeed, List<Waypoint> pWaypoints) : base(pPosition, pTexture, pHealth, pStrength)
    {
        _waypoints = pWaypoints;
        _speed = pSpeed;
    }

    public override void LoadObject()
    {
        _stateMachineEnemy = new StateMachineEnemy(this);
        base.LoadObject();
    }

    protected override void Movement(GameTime pGameTime)
    {
        for (int i = 0; i < _waypoints.Count; i++)
        {
            if (Vector2.Distance(Position, _waypoints[index].Position) <= 1f)
            {
                index = (index + 1) % _waypoints.Count; // if count exceeds the waypoints it'll reset back to 0 and restart.
            }
            Vector2 waypointDirection = Vector2.Normalize(_waypoints[index].Position - Position);
            Position += waypointDirection * (_speed / 2) * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
    }
    public void Attack(Player pPlayer)
    {
        Console.WriteLine("Enemy has attacked the player!!");
        pPlayer.TakeDamage(Strength);
    }
    public override void Die()
    {
        SceneManager.Instance.CurrentScene.RemoveObject(this);
    }
}