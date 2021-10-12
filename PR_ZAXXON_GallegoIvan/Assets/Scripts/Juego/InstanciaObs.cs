using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaObs : MonoBehaviour
{
    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    [SerializeField] GameObject obstaculo;
    [SerializeField] Transform initPos;

    //Variables de posicion para el vector3 de creacion
    float x;
    float y = 0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreaObst");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreaObst()
    {
        

        while (true) 
        {
            x = Random.Range(17f, -17f);
            Instantiate(obstaculo, new Vector3(x,y,initPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
