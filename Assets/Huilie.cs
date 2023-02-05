using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huilie : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    // Update is called once per frame
    void Awake()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
