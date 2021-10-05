using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Turbo();
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

        //Captura de los ejes en variables
        float despX = Input.GetAxis("Horizontal");
        float despY = Input.GetAxis("Vertical");
        
        //Variables de límites
        float maxX = 17f;
        float minX = -17f;
        float maxY = 15f;
        float minY = 0.5f;

        //Booleanas para verificacion de movimiento
        bool inLimitH = true;
        bool inLimitV = true;

        //Variable de velocidad de desplazamiento lateral
        float speedDesp = 10f;

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

}

    void Turbo()
    {

        //Este método controlará la velocidad del escenario mediante turbos asociados a las gatillos LT y RT

        /*Quizá debería ponerlo en un script para el escenario, pero creo que es má lógico dejarlo aqui con
          todo lo de la nave y llamarlo desde el script del escenario*/


        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/

        //Llamada a la velocidad de movimiento del escenario

        
        float speedIni = 5f;
        float speedScn = speedIni;

        //Variables de los botones que aceleran y frenan
        float acelerar = Input.GetAxis("Acelerador");
        float frenar = Input.GetAxis("Freno");


        /*-------------------------------
        --------------ACCION-------------
        -------------------------------*/

        if(acelerar > 0)
        {
            speedScn = speedIni + acelerar * 5f;
        }
        else if (frenar < 0)
        {
            speedScn = speedIni + frenar * 2.5f; 
        }
        else
        {
            speedScn = speedIni;
        }

        //print(speedScn);
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
}
