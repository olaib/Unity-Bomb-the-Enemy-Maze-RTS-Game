using System;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    BackgroundMusic,
}

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    private Dictionary<Sounds, AudioSource> soundDictionary;

    private const string ALREADY_EXISTS = " already exists in the dictionary.";
    private const string DOESNT_EXIST = " does not exist in the dictionary.";
    private const string MESSAGE = "Sound with name ";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        soundDictionary = new Dictionary<Sounds, AudioSource>();
    }

    public void AddSound(Sounds soundName, AudioSource audioSource)
    {
        if (!isExist(soundName))
        {
            soundDictionary.Add(soundName, audioSource);
        }
        else
        {
            logDoesntExist(soundName, ALREADY_EXISTS);
        }
    }

    private bool isExist(Sounds soundName)
    {
        return soundDictionary.ContainsKey(soundName);
    }

    public void PlaySound(Sounds soundName)
    {
        if (isExist(soundName))
        {
            soundDictionary[soundName].Play();
        }
        else
        {
            logDoesntExist(soundName, DOESNT_EXIST);
        }
    }

    private void logDoesntExist(Sounds soundName, string suffix)
    {
        Debug.LogWarning(MESSAGE + soundName + suffix);
    }

    public void StopSound(Sounds soundName)
    {
        if (isExist(soundName))
        {
            soundDictionary[soundName].Stop();
        }
        else
        {
            logDoesntExist(soundName, DOESNT_EXIST);
        }
    }

    public void SetVolume(Sounds soundName, float volume)
    {
        if (isExist(soundName))
        {
            soundDictionary[soundName].volume = volume;
        }
        else
        {
            logDoesntExist(soundName, DOESNT_EXIST);
        }
    }

    public void PlayLoopingSound(Sounds soundName)
    {
        if (isExist(soundName))
        {
            soundDictionary[soundName].loop = true;
            soundDictionary[soundName].Play();
        }
        else
        {
            logDoesntExist(soundName, DOESNT_EXIST);
        }
    }
}
