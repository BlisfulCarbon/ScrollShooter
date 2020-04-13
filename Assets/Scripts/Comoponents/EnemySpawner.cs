using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer = 2;

    public List<EnemyWave> stage;
    public float timer;

    public GameObject simpleEnemy;
    public GameObject hardEnemy;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            float waveNumber = Random.Range(1, 3);
            switch(waveNumber)
            {
                case 1:
                    SpawnSimpleWave();
                    break;
                case 2:
                    SpawnHardWave();
                    break;
            }
            timer = 0;
        }
    }

    private void SpawnSimpleWave()
    {
        Instantiate(simpleEnemy, new Vector3(transform.position.x - 1, transform.position.y), Quaternion.identity);
        Instantiate(simpleEnemy, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        Instantiate(simpleEnemy, new Vector3(transform.position.x + 0.8f, transform.position.y), Quaternion.identity);
    }

    private void SpawnHardWave()
    {
        Instantiate(hardEnemy, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }
}