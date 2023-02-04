using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour
{
    public float angle;
    public bool isMouseDown;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMouseDown)
        {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


}
