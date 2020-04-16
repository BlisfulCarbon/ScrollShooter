using System.Collections;
using ScrollShooter.Events;
using UnityEngine;
using ScrollShooter.Config;

namespace ScrollShooter.Managers
{
    public class BackgroundManager : BaseManager<BackgroundManager>
    {
        [Header("Game process variable")]
        public float speed = 0.2f;
        public Renderer bgRend;

        [Header("Game start variable")] 
        public float boostTime = Constants.timeForStartingGame;
        public float boostSpeed = 3f;

        private void Awake()
        {
            EventManager.gameStart.Subscribe(() => StartCoroutine(BoostScrolling(boostTime, boostSpeed)));
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