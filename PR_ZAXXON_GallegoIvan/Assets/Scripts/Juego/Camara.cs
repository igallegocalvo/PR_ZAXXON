using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    //Suavizado de movimientos
    [SerializeField] float smoothVelocity = 0.1f;
    [SerializeField] Vector3 cameraVelocity = Vector3.zero;

    //Posicion de la camara
    int altura = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + altura, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothVelocity);
    }
}
