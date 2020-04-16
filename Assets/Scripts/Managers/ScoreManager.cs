using UnityEngine.UI;
using ScrollShooter.Events;

namespace ScrollShooter.Managers
{
    public class ScoreManager : BaseManager<ScoreManager>
    {
        public Text scoreInput;
        private Score _score;

        private void Start()
        {
            EventManager.enemyDied.Subscribe(OnIncrementScore);
            _score = new Score();
        }

        private void OnIncrementScore()
        {
            _score.incrementScore();
            scoreInput.text = _score.getScore().ToString();
        }
    }
}