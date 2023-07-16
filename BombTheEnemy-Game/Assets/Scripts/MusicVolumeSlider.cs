using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource backgroundMusic;

    private void Start()
    {
        // event listener to the slider's value change event
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        volumeSlider.value = backgroundMusic.volume;
    }

    private void OnVolumeChanged(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
