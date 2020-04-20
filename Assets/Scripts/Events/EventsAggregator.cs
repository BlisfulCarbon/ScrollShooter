namespace ScrollShooter.Events
{
    public class EventsAggregator
    {
        // Menu events
        public static readonly ButtonStartPressedEvent buttonStartPressed = new ButtonStartPressedEvent();
        public static readonly ButtonToMenuPressedEvent buttonToMenuPressed = new ButtonToMenuPressedEvent();

        // Game stages
        public static readonly GameStartEvent gameStart = new GameStartEvent();
        public static readonly GameOverEvent gameOver = new GameOverEvent();

        // Game process        
        public static readonly EnemyDiedEvent enemyDied = new EnemyDiedEvent();
        public static readonly EnemyGetDamageEvent enemyGetDamage = new EnemyGetDamageEvent();
        public static readonly TakeShotEvent TakeShot = new TakeShotEvent();
        public static readonly EnemySmashIntoPlayerEvent enemySmashIntoPlayer = new EnemySmashIntoPlayerEvent();
    }
}