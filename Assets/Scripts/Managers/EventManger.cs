using System;
using UnityEngine;
using ScrollShooter.Managers;

namespace ScrollShooter.Events
{
    public class EventManager : BaseManager<EventManager>
    {
        public static GameStartEvent gameStart = new GameStartEvent();
        
        public static EnemyDiedEvent enemyDied = new EnemyDiedEvent();
        public static EnemyGetDamageEvent enemyGetDamage = new EnemyGetDamageEvent();
        public static TakeShotEvent TakeShot = new TakeShotEvent();
        public static EnemySmashIntoPlayerEvent enemySmashIntoPlayer = new EnemySmashIntoPlayerEvent();
    }
}