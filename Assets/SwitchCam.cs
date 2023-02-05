using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;


    private void OnTriggerEnter(Collider other)
    {
       SwitchCamera();
    }

    public void SwitchCamera()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
