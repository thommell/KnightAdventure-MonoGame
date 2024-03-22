using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.EnemyStateMachine;

public interface IEnemyState
{
    public Enemy Enemy { get; }
    public void OnStateEnter();
    public void OnStateExit();
    public void Update(GameTime pGameTime);
}