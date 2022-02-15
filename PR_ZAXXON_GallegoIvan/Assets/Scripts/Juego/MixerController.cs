using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{

    [SerializeField] private AudioMixer MixerVolume;


    public void SetMasterVolume(float sliderVolume)
    {
        MixerVolume.SetFloat("MasterVolume", Mathf.Log10(sliderVolume) * 20);
    }

    public void SetMusicVolume(float sliderVolume)
    {
        MixerVolume.SetFloat("MusicVolume", Mathf.Log10(sliderVolume) * 20);
    }

    public void SetSFXVolume(float sliderVolume)
    {
        MixerVolume.SetFloat("SFXVolume", Mathf.Log10(sliderVolume) * 20);
    }
}
