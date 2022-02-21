using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaObs : MonoBehaviour
{
    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    //Recall de initScript para obtener la velocidad de la escena
    InitGameScript recallInitGameScript;

    //creación del array de obstáculos
    [SerializeField] GameObject[] obstaculos;

    //Posición del instanciador
    [SerializeField] Transform initPos;

    //Variables de delimitación de espacios
    float maxL = -17f;
    float maxR = 17f;
    float maxY = 10f;
    float minY = 1f;
    

    //COLUMNAS INICIALES

    //variables para las columnas iniciales
    float vel;
    float dist;
    float intervalo;

    //Variables de posición para el vector3 de creación
    float x;
    float y = 0f;

    //Posición de la primera columna
    [SerializeField] float distPrimero;

    //angulo random
    public float randomAngle;


    // Start is called before the first frame update
    void Start()
    {

        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/

        //Llamada al script de InitGame
        recallInitGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();

        //Asigno la velocidad de la escena a una variable
        vel = recallInitGameScript.speedEscena;

        //La distancia entre obstáculos
        dist = 30f;


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/

        initObs();
            
        StartCoroutine("CreaObst");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initObs()
    {
        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/

        //La distancia a la que se posiciona el primer obstáculo
        distPrimero = 60f;


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/

        //Creación de las columnas iniciales
        for (float n = distPrimero; n < transform.position.z; n += dist)
        {
            x = Random.Range(maxL, maxR);
            int col = Random.Range(0, 3);

            Instantiate(obstaculos[col], new Vector3(x, y, n), Quaternion.identity);
        }
    }

    //Corrutina de generación de obstáculos
    IEnumerator CreaObst()
    {
        /*Quiero crear una función que haga variar los elementos a instanciar 
        en función de la velocidad de la escena*/

        /*Tambien quiero hacer que, al salir una pared después solo puedan
        salir cosas que no sean paredes durante cierto tiempo*/

        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/

        while (true) 
        {
            //Posiciono el instanciador
            Vector3 posicionInstancia = new Vector3(0f, 0f, initPos.position.z);

            //Creo variables para las posiciones limites
            float posX = Random.Range(maxL, maxR);
            float posY = Random.Range(minY, maxY);

            //Genero un numero random
            int obsRandom = Random.Range(0, obstaculos.Length);

            //Calculo el intervalo de generación de obstáculos
            intervalo = (dist / vel);
            

            //Posiciono los obstaculos
            if (obstaculos[obsRandom].tag == "Columna") {
                posicionInstancia = new Vector3(posX, 0f, initPos.position.z);
            }

            else if (obstaculos[obsRandom].tag == "Meteorito")
            {
                posicionInstancia = new Vector3(posX, posY, initPos.position.z);
            }

            else if (obstaculos[obsRandom].tag == "Pared")
            {
                posicionInstancia = new Vector3(0f, 0f, initPos.position.z);
            }

            //print(contadorPared);

            //Instancio los obstaculos
            Instantiate(obstaculos[obsRandom], posicionInstancia, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);
        }
    }

    //Detención de la corrutina
    public void Parar()
    {
        StopCoroutine("CreaObst");
    }
}
