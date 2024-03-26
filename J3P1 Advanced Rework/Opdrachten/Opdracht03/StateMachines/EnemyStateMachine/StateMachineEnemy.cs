using J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.EnemyStateMachine;
public class StateMachineEnemy
{
    private readonly Enemy _enemy;

    #region Variables

    private IEnemyState _currentState;
 
    #region States

    private EnemyPatrollingState _patrollingState;
    private EnemyIdlingState _idlingState;
    private EnemyChasingState _chasingState;
    private EnemyEvadingState _evadingState;
    #endregion
    #endregion
    #region Properties

    public EnemyPatrollingState PatrollingState => _patrollingState;
    public EnemyIdlingState IdlingState => _idlingState;
    public EnemyChasingState ChasingState => _chasingState;
    public EnemyEvadingState EvadingState => _evadingState;
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
        _chasingState = new EnemyChasingState(_enemy, this, 5f);
        _evadingState = new EnemyEvadingState(_enemy, this, 1.5f);
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