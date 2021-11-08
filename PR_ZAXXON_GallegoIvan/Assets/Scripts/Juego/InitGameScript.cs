using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameScript : MonoBehaviour
{

    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    public float speedEscena;
    public float escudo;
    

    // Start is called before the first frame update
    void Start()
    {
        speedEscena = 30f;
        escudo = 100f;
    }

    // Update is called once per frame
    void Update()
    {
            AceleracionEscenario();
    }

    void AceleracionEscenario()
    {
        //Aumento la velocidad gradualmente en cada frame
        speedEscena += 0.001f;
    }

}
