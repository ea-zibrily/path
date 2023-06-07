using UnityEngine.Audio;
using System;
using UnityEngine;
using Tsukuyomi.Utilities;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    
    private void Awake()
    {
        //Singleton Setup
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
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(SoundEnum soundName)
    {
        Sound _sound = Array.Find(sounds, sound => sound.name == soundName.ToString());
        if (_sound == null)
        {
            Debug.LogWarning($"Sound: {soundName} not found!");
            return;
        }
        
        _sound.source.Play();
    }

    public void Stop(SoundEnum soundName)
    {
        Sound _sound = Array.Find(sounds, sound => sound.name == soundName.ToString());

        _sound.source.Stop();
    }

    public void Pause(SoundEnum soundName)
    {
        Sound _sound = Array.Find(sounds, sound => sound.name == soundName.ToString());
        
        _sound.source.Pause();
    }

    public void VolumeEdit(float value)
    {
        Sound _sound = Array.Find(sounds, sound => sound.volume == value);
    }
}