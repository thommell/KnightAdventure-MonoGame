using J3P1_Advanced_Rework.Opdrachten.Opdracht02.EnemyStateMachine;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.StateMachines.EnemyStateMachine;
public class EnemyPatrollingState : IEnemyState
{
    private int indexOfWaypoints = 0;
    public EnemyPatrollingState(Enemy pEnemy) => Enemy = pEnemy;
    public Enemy Enemy { get; }
    public void OnStateEnter() {}
    public void OnStateExit() {}
    public void Update(GameTime pGameTime)
    {
        foreach (var waypoint in Enemy.Waypoints)
        {
            if (Vector2.Distance(Enemy.Position, Enemy.Waypoints[indexOfWaypoints].Position) <= 1f)
            {
                indexOfWaypoints = (indexOfWaypoints + 1) % Enemy.Waypoints.Count; // if count exceeds the waypoints it'll reset back to 0 and restart.
            }
            var waypointDirection = Vector2.Normalize(Enemy.Waypoints[indexOfWaypoints].Position - Enemy.Position);
            Enemy.Position += waypointDirection * (Enemy.Speed / 2) * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}