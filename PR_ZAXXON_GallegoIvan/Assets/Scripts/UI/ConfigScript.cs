using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour
{
    [SerializeField] Slider volumeSliderMusic;
    [SerializeField] Slider volumeSliderSFX;

    // Start is called before the first frame update
    void Start()
    {
        volumeSliderMusic.value = GameManager.volumeMusic;
        volumeSliderSFX.value = GameManager.volumeSFX;
    }

    public void CambiarVolMusic()
    {
        GameManager.volumeMusic = volumeSliderMusic.value;
        
    }

    public void CambiarVolSFX()
    {
        GameManager.volumeSFX = volumeSliderSFX.value;
    }
}
