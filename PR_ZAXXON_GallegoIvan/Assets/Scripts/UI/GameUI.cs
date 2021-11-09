using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    float tiempo;
    float velocidad;
    float distancia;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Escudo();
        Distancia();
    }

    void Escudo()
    {
        //Cojo el valor de los escudos del script del movimiento de la nave
        float escudo = GameObject.Find("Player").GetComponent<MovimientoNave>().escudo;

        //Cambio el texto
        GameObject.Find("txEscudos").GetComponent<Text>().text = "Nivel de los escudos: " + escudo + "%";
    }

    void Distancia()
    {
        //Calculo la distancia
        tiempo = Time.timeSinceLevelLoad;
        velocidad = GameObject.Find("InitGame").GetComponent<InitGameScript>().speedEscena;
        distancia = Mathf.Round(velocidad) * Mathf.Round(tiempo);

        //Cambio el texto
        GameObject.Find("txDistancia").GetComponent<Text>().text = distancia + "mt";

    }
}
