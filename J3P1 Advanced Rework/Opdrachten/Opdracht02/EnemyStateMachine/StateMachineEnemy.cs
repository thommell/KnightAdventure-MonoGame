using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
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

    public EnemyPatrollingState PatrollingState
    {
        get => _patrollingState;
        set => _patrollingState = value;
    }
    public EnemyIdlingState IdlingState
    {
        get => _idlingState;
        set => _idlingState = value;
    }
    public EnemyChasingState ChasingState
    {
        get => _chasingState;
        set => _chasingState = value;
    }
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
        _patrollingState = new EnemyPatrollingState();
        _idlingState = new EnemyIdlingState();
        _chasingState = new EnemyChasingState();
    }

    public void ChangeState(IEnemyState state)
    {
        
    }
}