using System;
using UnityEngine;
public class AudioManager : MonoSingleton<AudioManager>
{
    public Sound[] sounds;
    public bool IsSoundOff { get; private set; } = false;
    public delegate void SoundStateChanged();
    public static event SoundStateChanged OnSoundStateChanged;

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
        StopAllSoundsExcept(SoundName.ThemeSound, SoundName.ButtonSound);
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

    public void PlayRandomBladeSwipeSound()
    {
        SoundName randomSoundName = RandomBladeSwipeSound();
        Play(randomSoundName);
    }

    public SoundName RandomBladeSwipeSound()
    {
        Sound randomSound = RandomSound(
            SoundName.BladeFirstSwipeSound,
            SoundName.BladeSecondSwipeSound,
            SoundName.BladeThirdSwipeSound,
            SoundName.BladeFourthSwipeSound,
            SoundName.BladeFifthSwipeSound,
            SoundName.BladeSixthSwipeSound,
            SoundName.BladeSeventhSwipesound
        );
        return randomSound.soundName;
    }
    private Sound RandomSound(params SoundName[] soundNames)
    {
        int randomIndex = UnityEngine.Random.Range(0, soundNames.Length);
        return GetSound(soundNames[randomIndex]);
    }
    public void PauseAllSounds()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)  
            {
                s.source.Pause();
            }
        }
    }

    public void ResumeAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.UnPause();  
        }
    }
    public void ToggleSoundOff()
    {
        IsSoundOff = !IsSoundOff;
        if (IsSoundOff)
        {
            SoundOff();
        }
        else
        {
            SoundOn();
        }
        OnSoundStateChanged?.Invoke();
    }
    private void SoundOff()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = 0;  
            s.source.Stop();      
        }
    }
    private void SoundOn()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume;  
            
        }
    }

}
