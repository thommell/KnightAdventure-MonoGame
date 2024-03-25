using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.EnemyStateMachine;

public class EnemyIdlingState : IEnemyState
{
    private float _timeLeft;
    private readonly StateMachineEnemy _stateMachine;
    private readonly float _originalTime;
    public float TimeLeft => _timeLeft;
    public Enemy Enemy { get; }
    public EnemyIdlingState(Enemy pEnemy, StateMachineEnemy pStateMachine, float pTime)
    {
        _stateMachine = pStateMachine;
        Enemy = pEnemy;
        _timeLeft = pTime;
        _originalTime = _timeLeft;
    }
    public void OnStateEnter() {}
    public void OnStateExit()
    {
        _timeLeft = _originalTime;
    }
    public void Update(GameTime pGameTime)
    {
        Console.WriteLine(_timeLeft);
        _timeLeft -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
        if (TimeLeft > 0f) return;
        _stateMachine.ChangeState(_stateMachine.PatrollingState);
    }
}