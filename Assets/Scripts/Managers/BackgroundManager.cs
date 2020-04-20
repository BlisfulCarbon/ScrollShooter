using System.Collections;
using ScrollShooter.Config;
using ScrollShooter.Events;
using UnityEngine;

namespace ScrollShooter.Managers
{
    public class BackgroundManager : BaseManager
    {
        [Header("Game process variable")]
        public float speed = 0.2f;
        public Renderer bgRend;

        [Header("Game start variable")] 
        public float boostTime = Constants.timeForStartingGame;
        public float boostSpeed = 3f;
        
        
        
        [Header("Game start variable")] 
        public float slowDownTime = Constants.timeWhenEnemySmashIntoPlayer;
        public float slowDownSpeed = .3f;

        private void Awake()
        {
            EventsAggregator.gameStart.Subscribe(() => StartCoroutine(BoostScrolling(boostTime, boostSpeed)));
            EventsAggregator.enemySmashIntoPlayer.Subscribe(() => StartCoroutine(BoostScrolling(slowDownTime, slowDownSpeed)));
        }

        private void Update()
        {
            bgRend.material.mainTextureOffset = new Vector2(0, Time.time * speed);
        }
        
        private IEnumerator BoostScrolling(float boostTime, float boost)
        {
            speed *= boost;
            yield return new WaitForSeconds(boostTime);
            speed /= boost;
        }
    }
}