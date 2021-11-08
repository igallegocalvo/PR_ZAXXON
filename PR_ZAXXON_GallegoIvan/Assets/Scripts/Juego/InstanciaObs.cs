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

    //creaci�n del array de obst�culos
    [SerializeField] GameObject[] obstaculos;

    //Posici�n del instanciador
    [SerializeField] Transform initPos;

    //Variables de delimitaci�n de espacios
    float maxL = -17f;
    float maxR = 17f;
    float maxY = 10f;
    float minY = 1f;
    
    //COLUMNAS INICIALES

    //variables para las columnas iniciales
    float vel;
    float dist;
    float intervalo;

    //Variables de posici�n para el vector3 de creaci�n
    float x;
    float y = 0f;

    //Posici�n de la primera columna
    [SerializeField] float distPrimero;


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

        //La distancia entre obst�culos
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

        //La distancia a la que se posiciona el primer obst�culo
        distPrimero = 60f;


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/

        //Creaci�n de las columnas iniciales
        for (float n = distPrimero; n < transform.position.z; n += dist)
        {
            x = Random.Range(maxL, maxR);
            
            Instantiate(obstaculos[0], new Vector3(x, y, n), Quaternion.identity);
        }
    }

    //Corrutina de generaci�n de obst�culos
    IEnumerator CreaObst()
    {
        /*Quiero crear una funci�n que haga variar los elementos a instanciar 
        en funci�n de la velocidad de la escena*/

        /*Tambien quiero hacer que, al salir una pared despu�s solo puedan
        salir cosas que no sean paredes durante cierto tiempo*/

        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/

        //Booleana para saber si salio pared
        bool isWall = false;
        int contadorPared = 0;


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
            int quePongo;

            //Calculo el intervalo de generaci�n de obst�culos
            intervalo = dist / vel;

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

            


            //Contador paredes
            /*if (obstaculos[obsRandom].tag == "Pared")
            {
                isWall = true;
                contadorPared = 0;
                print("Sali� pared, isWall es: " + isWall);
            }
            else
            {
                isWall = false;
                contadorPared++;
                print("No sali� pared, isWall es: " + isWall);
            }

            if(contadorPared <= 5)
            {
                quePongo = Random.Range(0, 1);
            }
            else
            {
                quePongo = Random.Range(0, obstaculos.Length);
            }*/

            //print(contadorPared);

            //Instancio los obstaculos
            Instantiate(obstaculos[obsRandom], posicionInstancia, Quaternion.identity);
            //Instantiate(obstaculos[quePongo], posicionInstancia, Quaternion.identity);

            /*if (isWall)
            {
                contadorPared++;
                obsRandom = Random.Range(0, 1);
            }

            if (contadorPared == 5)
            {
                isWall = false;
                contadorPared = 0;
                obsRandom = Random.Range(0, obstaculos.Length);
            }

            //Compruebo si sali� pared y delimito el array
            if (isWall)
            {
                obsRandom = Random.Range(0, 1);
            }
            else
            {
                obsRandom = Random.Range(0, obstaculos.Length);
            }*/

            yield return new WaitForSeconds(intervalo);
        }
    }

    //Detenci�n de la corrutina
    public void Parar()
    {
        StopCoroutine("CreaObst");
    }
}
