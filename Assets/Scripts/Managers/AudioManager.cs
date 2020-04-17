using System.Collections.Generic;
using ScrollShooter.Data;
using UnityEngine;

namespace ScrollShooter.Managers
{
    public class AudioManager : BaseManager
    {
        public List<Sound> sounds;

        private void Start()
        {
            Debug.Log("Audio Manager start");
            Play(SoundTitles.MenuMusic);

            EventsManager.gameStart.Subscribe(() =>
            {
                Stop(SoundTitles.MenuMusic);
                Play(SoundTitles.FirstSceneMusic);
            });

            EventsManager.gameOver.Subscribe(() =>
            {
                Stop(SoundTitles.FirstSceneMusic);
                Play(SoundTitles.MenuMusic);
            });

            EventsManager.enemyDied.Subscribe(() => Play(SoundTitles.DestroyShip));
            EventsManager.enemyGetDamage.Subscribe(() => Play(SoundTitles.DamageEnemy));
            EventsManager.TakeShot.Subscribe(() => Play(SoundTitles.Laser));
            EventsManager.enemySmashIntoPlayer.Subscribe(() => Play(SoundTitles.GameOver));
        }

        private void Awake()
        {
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        private void Play(string name)
        {
            var currentSound = sounds.Find(sound => sound.name == name);
            if (currentSound == null)
            {
                Debug.LogWarning(GetType().Name + " -> Sound: " + name + " not found!");
                return;
            }

            try
            {
                currentSound.source.Play();
            }
            catch (MissingReferenceException e)
            {
                Debug.LogWarning("SoundManager -> Play ( name: " + name + ") " + e);
            }
        }


        private void Stop(string name)
        {
            var currentSound = sounds.Find(sound => sound.name == name);
            if (currentSound == null)
            {
                Debug.LogWarning(GetType().Name + " -> Sound: " + name + " not found!");
                return;
            }

            try
            {
                currentSound.source.Stop();
            }
            catch (MissingReferenceException e)
            {
                Debug.LogWarning("SoundManager -> Play ( name: " + name + ") " + e);
            }
        }
    }

    public static class SoundTitles
    {
        public const string MenuMusic = "MenuMusic";
        public const string FirstSceneMusic = "FirstSceneMusic";
        public const string DestroyShip = "DestroyShip";
        public const string DamageEnemy = "DamageEnemy";
        public const string Laser = "Laser";
        public const string GameOver = "GameOver";
    }
}