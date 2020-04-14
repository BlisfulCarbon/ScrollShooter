using UnityEngine;
using UnityEngine.UI;
using ScrollShooter.Events;

namespace ScrollShooter.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public Text scoreInput;
        private Score _score;

        private void Start()
        {
            EventAggregator.enemyDied.Subscribe(OnIncrementScore);
            _score = new Score();
        }

        private void OnIncrementScore(Actor actor)
        {
            _score.incrementScore();
            scoreInput.text = _score.getScore().ToString();
        }
    }
}