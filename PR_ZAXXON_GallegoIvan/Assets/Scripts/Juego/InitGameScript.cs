using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameScript : MonoBehaviour
{

    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    private float speedIni;
    public int nivel;
    public float multiplicador;
    public float speedEscena;

    

    // Start is called before the first frame update
    void Start()
    {
        MovimientoEscenario();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovimientoEscenario()
    {
        //Seteo velocidad inicial
        speedIni = 20f;

        //Seteo nivel, esta variable tendría que variar según el nivel o la escena
        nivel = 1;

        //Seteo del multiplicador. Esto hará que la velocidad se incremente gradualmente según el nivel en el que estemos
        multiplicador = 1 + (nivel / 10f);

        //Seteo la velocidad de los objetos del escenario en funcion de la velocidad inicial y el nivel
        speedEscena = speedIni * multiplicador;
    }

}
