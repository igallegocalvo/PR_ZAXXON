using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTexturas : MonoBehaviour
{
    InitGameScript recallInitGameScript;
    float scrollSpeed;

    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        recallInitGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //scrollSpeed = recallInitGameScript.speedEscena;
        scrollSpeed = recallInitGameScript.speedEscena;
        float offset = Time.time * scrollSpeed;

        Vector2 desp = new Vector2(0, -offset);
        print(scrollSpeed);

        render.material.SetTextureOffset("_MainTex", desp);
        render.material.SetTextureOffset("_BumpMap", desp);
    }
}
