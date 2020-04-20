using System.Collections;
using ScrollShooter.Config;
using ScrollShooter.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScrollShooter.Managers
{
    public class GameProcessManager : BaseManager
    {
        public enum GameState
        {
            menu,
            gameProcess,
            gameOver
        }

        public string gameMenuScene;
        public string gameOverScene;
        public string gameScene;

        public GameState state;
        public float timeWaitForGameOver = Constants.timeWhenEnemySmashIntoPlayer;

        [Header("Player initialization")] public GameObject player;
        public Transform initPosition;



        private void Awake()
        {
            EventsAggregator.buttonStartPressed.Subscribe(() => StartCoroutine(StartGame()));
            EventsAggregator.gameOver.Subscribe(() => StartCoroutine(GameOver(timeWaitForGameOver)));
            EventsAggregator.buttonToMenuPressed.Subscribe(
                () => StartCoroutine(GoToMenu(Constants.timeForStartingGame)));

            EventsAggregator.enemySmashIntoPlayer.Subscribe(PreparingGameOver);
        }

        private IEnumerator GoToMenu(float waitFor)
        {
            yield return new WaitForSeconds(waitFor);
            SceneManager.LoadScene(gameMenuScene);
        }

        private IEnumerator StartGame()
        {
            yield return new WaitForSeconds(Constants.timeForStartingGame);
            state = GameState.gameProcess;

            SceneManager.LoadScene(gameScene);
            StartCoroutine(CreatePlayer());
            EventsAggregator.gameStart.Publish();
        }

        private IEnumerator CreatePlayer()
        {
            yield return new WaitForSeconds(.2f);
            var createdPlayer = Instantiate(player, initPosition.position, Quaternion.identity);

            //TODO: Player have to move up some time when game is starting
            createdPlayer.GetComponent<Rigidbody2D>().AddForce(Vector2.up / 2, ForceMode2D.Impulse);
            StartCoroutine(RemoveAcceleration(createdPlayer));
        }

        // TODO: Bad decision
        private IEnumerator RemoveAcceleration(GameObject createdPlayer)
        {
            yield return new WaitForSeconds(2f);
            createdPlayer.GetComponent<Rigidbody2D>().AddForce(Vector2.down / 2, ForceMode2D.Impulse);
        }

        private void PreparingGameOver()
        {
            state = GameState.gameOver;
            EventsAggregator.gameOver.Publish();
        }

        private IEnumerator GameOver(float waitingTime)
        {
            yield return new WaitForSeconds(waitingTime);
            SceneManager.LoadScene(gameOverScene);
        }
    }
}