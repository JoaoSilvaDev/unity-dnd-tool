using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Toggle(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.playing)
        {
            s.playing = false;
            s.source.Stop();
        }
        else
        {
            s.playing = true;
            s.source.Play();
        }
    }

    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
