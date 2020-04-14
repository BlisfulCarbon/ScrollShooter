using UnityEngine;

namespace ScrollShooter.Events
{
    public class EventAggregator : MonoBehaviour
    {
        public static EnemyDiedEvent enemyDied = new EnemyDiedEvent();
        public static EnemyGetDamageEvent enemyGetDamage = new EnemyGetDamageEvent();
        public static TakeShotEvent TakeShot = new TakeShotEvent();
        public static EnemySmashIntoPlayerEvent enemySmashIntoPlayer = new EnemySmashIntoPlayerEvent();
    }
}