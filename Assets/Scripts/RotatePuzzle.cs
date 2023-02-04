using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour
{
    public float angle;
    public bool isMouseDown;
    public float checkAngle;

    public float prevAngle;

    public int rotadraaing;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMouseDown)
        {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            checkAngle = transform.eulerAngles.z;
        }

        if (prevAngle - checkAngle > 10)
        {
            if (checkAngle > 180)
            {
                rotadraaing--;
            }
            else
            {
                rotadraaing++;
            }
        }



        if (rotadraaing < 0) rotadraaing = 0;

        prevAngle = checkAngle;
    }
}
