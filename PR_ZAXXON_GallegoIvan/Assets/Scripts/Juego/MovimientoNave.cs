using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoNave : MonoBehaviour
{
    /*-------------------------------
    ------------VARIABLES------------
    -------------------------------*/

    //InputSystem
    ZaxxonControl zaxxonControl;

    //recall al Init Game
    private InitGameScript recallInitGameScript;
    
    //private Rigidbody rb;

    //Estoy vivo?
    public bool alive;

    //Nivel del escudo
    public float escudo;

    //AudioSource
    private AudioSource audioSource;
    [SerializeField] AudioClip explosion;

    //Variable para puntuaciones
    public string puntuacion;

    //Explosion mortal de la muerte
    public GameObject explosionParticulas;

    //Variables para el desplazamiento de la nave
    public Vector2 desp, rotNave;

    //Angulo de rotacion
    public float angle_X, angle_Y;

    //Inicio el nuevo Input System
    private void Awake()
    {
        //Instancio la clase
        zaxxonControl = new ZaxxonControl();

        //Detecto el joystick izquierdo
        zaxxonControl.Nave.Movimiento.performed += ctx => desp = ctx.ReadValue<Vector2>();
        zaxxonControl.Nave.Movimiento.canceled += ctx => desp = Vector2.zero ;

        //Detecto el joystic derecho
        zaxxonControl.Nave.Rotacion.performed += ctx => rotNave = ctx.ReadValue<Vector2>();
        zaxxonControl.Nave.Rotacion.canceled += ctx => rotNave = Vector2.zero;

        //Detecto disparo1
        zaxxonControl.Nave.Disparo1.started += ctx => DisparoNorm();

        //Detecto disparo2
        zaxxonControl.Nave.Disparo2.started += ctx => DisparoEsp();

        //Apago el CamShake por si acaso
        CamShake.Instance.ShakeCam(0f, .5f);
    }

    // Start is called before the first frame update
    void Start()
    {

        //Llamada al script de InitGame
        recallInitGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();

        //Componente AudioSource
        audioSource = GetComponent<AudioSource>();

        //Componente Rigidbody
        //rb = GetComponent<Rigidbody>();

        //Valor de escudo
        escudo = recallInitGameScript.escudo;

        //Booleana para ver si etoy vivo
        alive = true;

        //Oculto el Canvas de GameOver
        GameObject.Find("CanvasGameOver").GetComponent<Canvas>().enabled = false;

        //Localizo la explosión, la asigno y la seteo en false
        explosionParticulas = GameObject.Find("Explosion");
        explosionParticulas.SetActive(false);

        //Activo las particulas de "velocidad" por si acaso
        GameObject.Find("ParticlesBG").SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Movimiento();
            GuardaDistancia();
            Rotacion();
        }
    }


    void Movimiento()
    {

        /*-------------------------------
        ------------VARIABLES------------
        -------------------------------*/

        //Posicion del objeto en los ejes
        float posicionX = transform.position.x;
        float posicionY = transform.position.y;
        float posicionZ = transform.position.z;  //Sin uso

        //Rotacion del objeto
        float rotacionNave = transform.rotation.z;

        //Variables de límites
        float maxX = 25f;
        float minX = -25f;
        float maxY = 10f;
        float minY = 0.5f;

        float rotMax = 0.7f;
        float rotMin = -0.7f;


        //Booleanas para verificacion de movimiento
        bool inLimitH = true;
        bool inLimitV = true;

        bool inLimitRot = true;

        //Variable de velocidad de desplazamiento lateral
        float speedDesp = recallInitGameScript.speedEscena/1.5f;


        /*-------------------------------
        -----------RESTRICCION-----------
        -------------------------------*/
        //Restriccion horizontal
        if (posicionX >= maxX && desp.x > 0 || posicionX <= minX && desp.x < 0)
        {
            inLimitH = false;
        }

        //Restriccion vertical
        if (posicionY >= maxY && desp.y > 0 || posicionY <= minY && desp.y < 0)
        {
            inLimitV = false;
        }

        //Restriccion rotacion
        if (rotacionNave >= rotMax && rotNave.x < 0|| rotacionNave <= rotMin && rotNave.x > 0)
        {
            inLimitRot = false;
        }


        /*-------------------------------
        ------------MOVIMIENTO-----------
        -------------------------------*/

        //Movimiento de la "nave" hacia up, down, left, right
        if (inLimitH)
        {
            transform.Translate(Vector3.right * desp.x * speedDesp * Time.deltaTime, Space.World);
        }
        if (inLimitV)
        {
            transform.Translate(Vector3.up * desp.y * speedDesp * Time.deltaTime, Space.World);
        }
        
        //Rotar la "nave" para ponerla de canto
        if (inLimitRot)
        {
            if(rotNave.x != 0)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotNave.x * 90);
            }            
        }
    }

    //Rotacion de la nave al desplazarse
    void Rotacion()
    {
        if(rotNave.x == 0)
        {
            transform.localEulerAngles = new Vector3(-desp.y * angle_Y, transform.localEulerAngles.y, desp.x * angle_X);
        }
    }

    //Disparos
    void DisparoNorm()
    {
        /*-------------------------------
       ------------VARIABLES------------
       -------------------------------*/


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/
        print("pichiun pichiun");
        
    }

    void DisparoEsp()
    {
        /*-------------------------------
       ------------VARIABLES------------
       -------------------------------*/


        /*-------------------------------
        -------------ACCIONES------------
        -------------------------------*/

        print("FUUUUUOOSSSH");
    }


    //Colisiones
    private void OnTriggerEnter(Collider other)
    {
        //Inicio la variable de daño
        float damage = 0;

        if (other.gameObject.layer == 6)
        {
            //Quizá estaría bien que estos datos de daño estuviesen en el propio script del obstáculo
            if(other.tag == "Columna")
            {
                damage = 10f;
            }
            else if(other.tag == "Meteorito")
            {
                damage = 20f;
            }
            else if(other.tag == "Pared")
            {
                damage = 50f;
            }

            escudo -= damage * GameManager.dificultad;

            //Llamo al temblor de cámara al colisionar
            CamShake.Instance.ShakeCam(5f, .5f);

            if(escudo <= 0)
            {
                escudo = 0f;
                alive = false;
                Fin();
            }

            //Molaria que la nave al colisionar temblase, lo dejo para mas adelante
        }
        else if(other.gameObject.layer == 7)
        {
            print("He pillao un Power-Up, yujuuuu!");
        }
        
    }

    //Fin de partida
    void Fin()
    {
        alive = false;
     
        //Paro el movimiento del escenario
        recallInitGameScript.speedEscena = 0f;
        //Paro la aceleracion para detenerlo del todo
        recallInitGameScript.aceleracion = 0f;
        //Envio la orden de detener la instanciacion de obstaculos
        GameObject.Find("PrefabGenerator").GetComponent<InstanciaObs>().SendMessage("Parar");
        //Oculto la nave
        DesactivarNave();
        //Lanzo pantalla de Game Over
        Invoke("GameOver", 1.5f);
    }

    public void GuardaDistancia()
    {
        if (alive)
        {
            puntuacion = GameObject.Find("txDistancia").GetComponent<Text>().text;
            GameObject.Find("txPuntuacion").GetComponent<Text>().text = "Has recorrido: " + puntuacion;
            GameManager.puntuacion = puntuacion;
        }
    }

    void GameOver()
    {
        GameObject.Find("CanvasGameOver").GetComponent<Canvas>().enabled = true;
    }

    void DesactivarNave()
    {
        GameObject.Find("PixelMakeVoyager_WithGuns").SetActive(false);
        GameObject.Find("ParticlesBG").SetActive(false);
        audioSource.PlayOneShot(explosion,1f);
        explosionParticulas.SetActive(true);
    }

    //Activar y descativar el Input System
    private void OnEnable()
    {
        zaxxonControl.Enable();
    }
    private void OnDisable()
    {
        zaxxonControl.Disable();
    }

}
