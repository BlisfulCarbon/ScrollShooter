using System.Collections.Generic;
using ScrollShooter.Events;
using UnityEngine;
using ScrollShooter.Data;

namespace ScrollShooter.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public List<Sound> sounds;

        private void Start()
        {
            Play(SoundTitles.FirstSceneMusic);
            EventAggregator.enemyDied.Subscribe((actor) => Play(SoundTitles.DestroyShip));
            EventAggregator.enemyGetDamage.Subscribe((actor) => Play(SoundTitles.DamageEnemy));
            EventAggregator.TakeShot.Subscribe((actor) => Play(SoundTitles.Laser));
            EventAggregator.enemySmashIntoPlayer.Subscribe((actor) => Play(SoundTitles.GameOver));
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(string name)
        {
            var currentSound = sounds.Find(sound => sound.name == name);
            if (currentSound == null)
            {
                Debug.LogWarning(GetType().Name + " -> Sound: " + name + " not found!");
                return;
            }

            currentSound.source.Play();
        }
    }

    public static class SoundTitles
    {
        public const string FirstSceneMusic = "FirstSceneMusic";
        public const string DestroyShip = "DestroyShip";
        public const string DamageEnemy = "DamageEnemy";
        public const string Laser = "Laser";
        public const string GameOver = "GameOver";
    }
}