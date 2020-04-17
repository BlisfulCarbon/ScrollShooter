using UnityEngine;
using UnityEngine.UI;

namespace ScrollShooter.Managers
{
    public class ScoreManager : BaseManager
    {
        private Text scoreInput;
        private Score _score;

        private void Start()
        {
            scoreInput = gameObject.GetComponent<Text>();
            
            EventsManager.enemyDied.Subscribe(OnIncrementScore);
            _score = new Score();
        }

        private void OnIncrementScore()
        {
            _score.incrementScore();
            scoreInput.text = _score.getScore().ToString();
        }
    }
}