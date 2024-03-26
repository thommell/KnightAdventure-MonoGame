using J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.EnemyStateMachine;

public class EnemyEvadingState : IEnemyState
{
    private float _stamina;
    private float _originalStamina;
    private StateMachineEnemy _stateMachine;
    private Player _player;
    public Enemy Enemy { get; }

    public EnemyEvadingState(Enemy pEnemy, StateMachineEnemy pStateMachine, float pStamina)
    {
        Enemy = pEnemy;
        _stateMachine = pStateMachine;
        _stamina = pStamina;
        _originalStamina = _stamina;
    }
    public float Stamina
    {
        get => _stamina;
        set => _stamina = value;
    }
    public void OnStateEnter()
    {
        _player = Enemy.Player; 
    }
    public void OnStateExit()
    {
        _stamina = _originalStamina;
    }
    public void Update(GameTime pGameTime)
    {
        UpdateStamina(pGameTime); 
        UpdatePosition(pGameTime);
    }
    private void UpdatePosition(GameTime pGameTime)
    {
        if (Stamina <= 0)
            _stateMachine.ChangeState(_stateMachine.IdlingState);
        Enemy.Position -= Vector2.Normalize(_player.Position - Enemy.Position) * (Enemy.Speed * 4.5f) * (float)pGameTime.ElapsedGameTime.TotalSeconds;
    }
    private void UpdateStamina(GameTime pGameTime) =>
        _stamina -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
}