using System;
using UnityEngine;
public class AudioManager : MonoSingleton<AudioManager>
{
    public Sound[] sounds;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;            
        }
    }
    public void MenuScenePlaySound()
    {
        StopAllSoundsExcept(SoundName.ThemeSound,SoundName.ButtonSound);
        PlayIfNotPlaying(SoundName.ThemeSound);
                
    }
    public void GameScenePlaySound()
    {
        StopAllSoundsExcept(SoundName.ButtonSound);        
    }
    private void PlayIfNotPlaying(SoundName soundName)
    {
        Sound sound = GetSound(soundName);
        if (sound != null && !sound.source.isPlaying)
        {
            Play(soundName);
        }
    }    
    public void Play(SoundName soundName)
    {
        Sound s = GetSound(soundName);
        if (s != null)
        {
            s.source.Play();
        }
    }
    public void Stop(SoundName soundName)
    {
        Sound s = GetSound(soundName);
        if (s != null)
        {
            s.source.Stop();
        }
    }
    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
    private void StopAllSoundsExcept(params SoundName[] exceptionSoundName)
    {
        foreach (Sound s in sounds)
        {
            if (!Array.Exists(exceptionSoundName, soundName => soundName == s.soundName))
            {
                s.source.Stop();
            }
        }
    }
    private Sound GetSound(SoundName soundName)
    {
        return Array.Find(sounds, sound => sound.soundName == soundName);
    }
}
