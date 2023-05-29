using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }
    public void SetFXVolume(float value)
    {
        audioMixer.SetFloat("FXVolume", Mathf.Log10(value) * 20);
    }
}
