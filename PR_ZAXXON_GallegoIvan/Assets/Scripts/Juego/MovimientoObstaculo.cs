using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{

    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    InitGameScript recallInitGameScript;



    // Start is called before the first frame update
    void Start()
    {
        //Llamada al script de InitGame
        recallInitGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.back * recallInitGameScript.speedEscena * Time.deltaTime);


        
        float posZ = transform.position.z;

        /*Quiero añadir un código para que se desactive la vista del objeto al sobrepasar 
        la nave para que si se trata de una pared, no bloquee la vista*/

        //Destruyo el objeto una vez sobrepasado cuerto punto
        if (posZ < -20)
        {
            Destroy(gameObject);
        }
    }
}
