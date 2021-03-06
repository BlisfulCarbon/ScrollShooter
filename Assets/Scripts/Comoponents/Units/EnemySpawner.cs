﻿using ScrollShooter.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScrollShooter.Components
{
    public class EnemySpawner : BaseComponent, IActor
    {
        public float spawnTimer = 2;
        public float timer;

        public GameObject simpleEnemy;
        public GameObject hardEnemy;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnTimer)
            {
                float waveNumber = Random.Range(1, 3);
                switch (waveNumber)
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
            Instantiate(simpleEnemy, new Vector3(transform.position.x - .05f, transform.position.y), Quaternion.identity);
            Instantiate(simpleEnemy, new Vector3(transform.position.x + .8f, transform.position.y),
                Quaternion.identity);
        }

        private void SpawnHardWave()
        {
            Instantiate(hardEnemy, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}