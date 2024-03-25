using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.StateMachines.EnemyStateMachine;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.EnemyStateMachine;
public class StateMachineEnemy
{
    private readonly Enemy _enemy;

    #region Variables

    private IEnemyState _currentState;
 
    #region States

    private EnemyPatrollingState _patrollingState;
    private EnemyIdlingState _idlingState;
    private EnemyChasingState _chasingState;
    #endregion
    #endregion
    #region Properties

    public EnemyPatrollingState PatrollingState => _patrollingState;
    public EnemyIdlingState IdlingState => _idlingState;
    public EnemyChasingState ChasingState => _chasingState;

    public IEnemyState CurrentState
    {
        get => _currentState;
        set => _currentState = value;               
    }
    #endregion
    public StateMachineEnemy(Enemy pEnemy)
    {
        _enemy = pEnemy;
        SetupStates();
    }
    private void SetupStates()
    {
        _patrollingState = new EnemyPatrollingState(_enemy);
        _idlingState = new EnemyIdlingState(_enemy, this, 2f);
        _chasingState = new EnemyChasingState(_enemy, this, 1f);
        ChangeState(PatrollingState);
    }
    public void UpdateState(GameTime pGameTime)
    {
        CurrentState.Update(pGameTime);
    }
    public void ChangeState(IEnemyState state)
    {
        state.OnStateExit();
        CurrentState = state;
        state.OnStateEnter();
    }
}