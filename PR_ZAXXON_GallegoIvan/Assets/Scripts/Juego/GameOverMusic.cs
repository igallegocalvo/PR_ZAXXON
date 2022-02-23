using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMusic : MonoBehaviour
{
    AudioSource audioSource;
    MovimientoNave recallMovimientoNave;

    public AudioClip juego;
    public AudioClip gameOver;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        recallMovimientoNave = GameObject.Find("Player").GetComponent<MovimientoNave>();
    }

    // Update is called once per frame
    void Update()
    {
        CambiaMusica();
    }
    void CambiaMusica()
    {
        if (recallMovimientoNave.alive == false)
        {
            audioSource.Stop();
            audioSource.clip = gameOver;
            audioSource.Play();
        }
    }
}
