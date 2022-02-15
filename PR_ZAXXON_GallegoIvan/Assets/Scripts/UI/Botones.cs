using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public void CambiarEscena(int scene)
    {
        SceneManager.LoadScene(scene);
    }


    //Seteo el nivel de dificultad. Esta variable quiero usarla como multiplicador de daño de colisiones
    public void Dificultad(int diff)
    {
        GameManager.dificultad = diff;
    }
}
