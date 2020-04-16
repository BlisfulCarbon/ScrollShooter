using System;
using System.Collections;
using ScrollShooter.Events;
using ScrollShooter.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScrollShooter.Config;

public class GameProcessManager : BaseManager<GameProcessManager>
{
    public GameState state;
    [Header("Player initialization")]
    public GameObject player;
    public Transform initPosition;

    public string gameMenuScene;
    public string gameOverScene;
    public string gameScene;

    private void Awake()
    {

        Debug.Log("Game process awake");
        EventManager.gameStart.Subscribe(()=>StartCoroutine(StartGame()));
        EventManager.enemySmashIntoPlayer.Subscribe(EndGame);
        

    }

    private void Start()
    {
        Debug.Log("Start");
        
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(Constants.timeForStartingGame);
        state = GameState.gameProcess;
        SceneManager.LoadScene(gameScene);
        StartCoroutine(CreatePlayer());
    }

    private IEnumerator CreatePlayer()
    {
        yield return new WaitForSeconds(.2f);
       GameObject createdPlayer = Instantiate(player, initPosition.position, Quaternion.identity);
       createdPlayer.GetComponent<Rigidbody2D>().AddForce(createdPlayer.transform.position, ForceMode2D.Force);
    }
    
    private void EndGame()
    {
        state = GameState.gameOver;
        SceneManager.LoadScene(gameOverScene);
    }
    
    public enum GameState
    {
        menu, gameProcess, gameOver    
    }
}
