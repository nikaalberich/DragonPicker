using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Знаходження аудіо джерела на головній камері
        audioSource = Camera.main.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found on the main camera!");
        }
        else
        {
            // Встановлення початкової гучності
            audioSource.volume = 1f;
        }
    }

    public void SetVolume(float volume)
    {
        // Зміна гучності музики в аудіо мікшері
        audioMixer.SetFloat("volume", volume);
    }

    public float GetVolume()
    {
        // Отримання поточного значення гучності з аудіо мікшера
        audioMixer.GetFloat("volume", out float volume);
        return volume;
    }
}
