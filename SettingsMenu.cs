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
        // ����������� ���� ������� �� ������� �����
        audioSource = Camera.main.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found on the main camera!");
        }
        else
        {
            // ������������ ��������� �������
            audioSource.volume = 1f;
        }
    }

    public void SetVolume(float volume)
    {
        // ���� ������� ������ � ���� �����
        audioMixer.SetFloat("volume", volume);
    }

    public float GetVolume()
    {
        // ��������� ��������� �������� ������� � ���� ������
        audioMixer.GetFloat("volume", out float volume);
        return volume;
    }
}
