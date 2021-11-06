using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    private InitGameScript recallInitGameScript;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        //Llamada al script de InitGame
        recallInitGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Disparo();
    }

    void Movimiento()
    {

        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/

        //Posicion del objeto en los ejes
        float posicionX = transform.position.x;
        float posicionY = transform.position.y;
        float posicionZ = transform.position.z;

        //Rotacion del objeto
        float rotacionNave = transform.rotation.z;

        //Captura de los ejes en variables
        float despX = Input.GetAxis("Horizontal");
        float despY = Input.GetAxis("Vertical");

        float rotNave = Input.GetAxis("HorizontalJ2");
        
        //Variables de límites
        float maxX = 17f;
        float minX = -17f;
        float maxY = 10f;
        float minY = 0.5f;

        float rotMax = 0.7f;
        float rotMin = -0.7f;


        //Booleanas para verificacion de movimiento
        bool inLimitH = true;
        bool inLimitV = true;

        bool inLimitRot = true;

        //Variable de velocidad de desplazamiento lateral
        float speedDesp = recallInitGameScript.speedEscena;


        /*-------------------------------
        -----------RESTRICCION-----------
        -------------------------------*/
        //Restriccion horizontal
        if (posicionX >= maxX && despX > 0 || posicionX <= minX && despX < 0)
        {
            inLimitH = false;
        }

        //Restriccion vertical
        if (posicionY >= maxY && despY > 0 || posicionY <= minY && despY < 0)
        {
            inLimitV = false;
        }

        //Restriccion rotacion
        if (rotacionNave >= rotMax && rotNave < 0|| rotacionNave <= rotMin && rotNave > 0)
        {
            inLimitRot = false;
        }


        /*-------------------------------
        ------------MOVIMIENTO-----------
        -------------------------------*/

        //Movimiento de la "nave" hacia up, down, left, right
        if (inLimitH)
        {
            transform.Translate(Vector3.right * despX * speedDesp * Time.deltaTime, Space.World);
        }
        if (inLimitV)
        {
            transform.Translate(Vector3.up * despY * speedDesp * Time.deltaTime, Space.World);
        }
        
        //Rotar la "nave" para ponerla de canto
        if (inLimitRot)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotNave * 200f);
        }
        

    }

    void Disparo()
    {
        /*-------------------------------
       ------------VARIABLES------------
       -------------------------------*/

        //Controles de disparo
        bool disparoNorm = Input.GetButtonDown("Fire1");
        bool disparoEsp = Input.GetButton("Fire2");


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/

        //Disparo normal
        if (disparoNorm)
        {
            print("pium");
        }

        //Disparo especial
        if (disparoEsp)
        {
            /*Seguramente tenga que hacer corrutinas.
             La idea es hacer varios tipos de disparo especial que puedan seleccionarse mediante la 
            cruceta direccional.
            Supongo que tendria que crear un switch para los tipos de disparo.
            Tengo que pensar cómo hacer los disparos o qué quiero hacer más bien.
            De momento lo voy a dejar*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            
            //print("Mechocao");

            //Molaria que la nave al colisionar temblase, lo dejo para mas adelante
        }
        else if(other.gameObject.layer == 7)
        {
            print("he pillao un Power-Up, yujuuuu!");
        }
    }

    
}
