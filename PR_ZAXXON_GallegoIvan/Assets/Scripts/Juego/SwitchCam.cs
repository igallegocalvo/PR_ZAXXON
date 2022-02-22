using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{

    ZaxxonControl zaxxonControl;

    GameObject camTrasera, camCenital;

    public bool cenital;

    private void Awake()
    {
        zaxxonControl = new ZaxxonControl();

        zaxxonControl.Camara.CambiaCamara.started += ctx => CambiaCam();
    }

    private void Start()
    {
        camTrasera = GameObject.Find("CamTrasera");
        camCenital = GameObject.Find("CamCenital");

        camTrasera.SetActive(true);
        camCenital.SetActive(false);

        cenital = false;

    }
    void CambiaCam()
    {
        

        if (!cenital)
        {
            cenital = true;
            camTrasera.SetActive(false);
            camCenital.SetActive(true);
        }
        else
        {
            cenital = false;
            camTrasera.SetActive(true);
            camCenital.SetActive(false);
        }
    }

    private void OnEnable()
    {
        zaxxonControl.Enable();
    }
    private void OnDisable()
    {
        zaxxonControl.Disable();
    }
}
