using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;
using Microsoft.Xna.Framework;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.EnemyStateMachine;
public class EnemyPatrollingState : IEnemyState
{
    private int indexOfWaypoints = 0;
    public EnemyPatrollingState(Enemy pEnemy) => Enemy = pEnemy;
    public Enemy Enemy { get; }
    public void OnStateEnter() {}
    public void OnStateExit() {}
    public void Update(GameTime pGameTime)
    {
        if (Enemy.Waypoints == null)
        {
            
        }
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