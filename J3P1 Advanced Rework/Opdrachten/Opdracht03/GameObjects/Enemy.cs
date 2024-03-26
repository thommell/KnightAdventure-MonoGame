using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.EnemyStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;

public class Enemy : Humanoid
{
    private List<Waypoint> _waypoints;
    private float _chasingSize;
    private Player _player;
    private float _speed;
    private StateMachineEnemy _stateMachineEnemy;
    #region Properties

    public List<Waypoint> Waypoints
    {
        get => _waypoints;
        set => _waypoints = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public Player Player => _player;

    #endregion
    public Enemy(Vector2 pPosition, Texture2D pTexture, int pHealth, int pStrength, int pSpeed, List<Waypoint> pWaypoints) : base(pPosition, pTexture, pHealth, pStrength)
    {
        Speed = pSpeed;
        _waypoints = pWaypoints;
    }
    public override void LoadObject()
    {
        _stateMachineEnemy = new StateMachineEnemy(this);
        _player = GetPlayer();
        _chasingSize = Texture.Width * 2.5f;
        base.LoadObject();
    }

    public override void UpdateObject(GameTime pGameTime)
    {
        CheckState();
        base.UpdateObject(pGameTime);
    }
    public void Attack(Player pPlayer)
    {
        Console.WriteLine("Enemy has attacked the player!!");
        pPlayer.TakeDamage(Strength);
    }
    private void CheckState()
    {
        if (_player.HasWeapon && _player.HasShield)
            _stateMachineEnemy.ChangeState(IsChasing() ? _stateMachineEnemy.EvadingState : _stateMachineEnemy.PatrollingState);  
        else
            _stateMachineEnemy.ChangeState(IsChasing() ? _stateMachineEnemy.ChasingState : _stateMachineEnemy.PatrollingState);
        
    }
    protected override void Movement(GameTime pGameTime)
    {
        //Console.WriteLine(_stateMachineEnemy.CurrentState);
        _stateMachineEnemy.UpdateState(pGameTime);
    }
    public override void Die() =>
        SceneManager.Instance.CurrentScene.RemoveObject(this);
    private Player GetPlayer()
    {
        foreach (var obj in SceneManager.Instance.CurrentScene.GameObjects)
        {
            if (obj is not Player playerObject) continue;
            return playerObject;
        }
        return null;
    }
    //deprecated
    /*
    private List<Waypoint> GetWaypoints()
    {
        var waypointList = new List<Waypoint>();
        foreach (var obj in SceneManager.Instance.CurrentScene.GameObjects)
        {
            if (obj is not Waypoint waypoint) continue;
            waypointList.Add(waypoint);
        }
        return waypointList;
    }
    */
    private bool IsChasing()
    {
        return Vector2.Distance(_player.Position, Position) <= _chasingSize;
    }
}