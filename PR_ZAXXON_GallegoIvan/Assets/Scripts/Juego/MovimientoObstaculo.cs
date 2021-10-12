using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{

    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    private InitGameScript initGameScript;
    GameObject recallInitGame;


    // Start is called before the first frame update
    void Start()
    {
        recallInitGame = GameObject.Find("InitGame");
        initGameScript = recallInitGame.GetComponent<InitGameScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.back * initGameScript.speedEscena * Time.deltaTime);

        float posZ = transform.position.z;
        
        if (posZ < -20)
        {
            Destroy(gameObject);
        }
    }
}
