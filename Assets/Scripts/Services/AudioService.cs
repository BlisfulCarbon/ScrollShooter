using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    public static AudioService instance;
    public List<Sound> sounds;

    private void Start()
    {
        Play("FirstSceneMusic");
        EventAggregator.enemyDied.Subscribe(OnShipDestroy); 
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

    private void OnShipDestroy(Actor actor)
    {
        Play("DestroyShip");
    }
}