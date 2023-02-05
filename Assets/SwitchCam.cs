using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private bool EEEE;


    

    private void OnTriggerEnter(Collider other)
    {
       EventSystem<WorldMessage>.InvokeEvent(EventType.onUIEnter, new WorldMessage(transform, "PRESS E TO BUILD"));
        EEEE = true;
    }

    private void Update()
    {
        if (EEEE)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchCamera();
                EEEE = false;
                Destroy(gameObject);
                EventSystem.InvokeEvent(EventType.onUIExit);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        EventSystem.InvokeEvent(EventType.onUIExit);
    }

    public void SwitchCamera()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
