using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameScript : MonoBehaviour
{

    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    private float speedIni = 5f;
    private int nivel = 1;
    public float speedEscena;

    // Start is called before the first frame update
    void Start()
    {
        //Seteo la velocidad de los objetos del escenario en funcion de la velocidad inicial y el nivel
        speedEscena = speedIni * nivel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
