using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static float musicVolume, sfxVolume;

    public static bool isMainMenuMusicPlayed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicVolume = 1f;
        sfxVolume = 1f;

        isMainMenuMusicPlayed = true;
        PlayMusic("Main Menu");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" && isMainMenuMusicPlayed == false)
        {
            PlayMusic("Main Menu");
            isMainMenuMusicPlayed = true;
        }
        else if (SceneManager.GetActiveScene().name == "LevelSelection" && isMainMenuMusicPlayed == false)
        {
            PlayMusic("Main Menu");
            isMainMenuMusicPlayed = true;
        }
        else if (SceneManager.GetActiveScene().name == "CutsceneDemoStart")
        {
            isMainMenuMusicPlayed = false;
        }
        else if (SceneManager.GetActiveScene().name == "CutsceneLevel1Opening")
        {
            isMainMenuMusicPlayed = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            isMainMenuMusicPlayed = false;
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PauseMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Pause();
        }
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Stop();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicVolume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        sfxVolume = volume;
    }

}
