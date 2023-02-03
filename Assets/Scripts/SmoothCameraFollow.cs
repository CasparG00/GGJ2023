using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0,2)]
    public float damping;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 movepos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movepos, ref velocity, damping);
    }
}
