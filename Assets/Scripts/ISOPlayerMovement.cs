using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISOPlayerMovement : MonoBehaviour
{
    public CharacterController charControl;
    public float speed;
    public void FixedUpdate()
    {
        
        var h = (Vector3.right - Vector3.forward).normalized * Input.GetAxisRaw("Horizontal");
        var v = (Vector3.right - Vector3.back).normalized * Input.GetAxisRaw("Vertical");

        var wishDir = (h + v).normalized;

            charControl.Move(wishDir * speed);
    }
}

