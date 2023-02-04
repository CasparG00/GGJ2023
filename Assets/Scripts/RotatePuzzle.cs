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
    public bool aCheck;
    public int i = 1;

    public List<Transform> positions;
    public List<GameObject> items;
    public List<GameObject> knopjes;

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
            if (checkAngle > 30)
            {
                rotadraaing--;
            }
            else
            {
                rotadraaing++;
            }
        }



        if (rotadraaing < 0) rotadraaing = 0;

        if (aCheck)
        {
            if(rotadraaing > 2)
            {
                if(items != null) Destroy(items[i].gameObject);
                if (knopjes != null) knopjes[i].SetActive(true);
                i++;
                if (i >= 3)
                {
                    i = 3;
                    this.gameObject.SetActive(false);
                }
                items[i].SetActive(true);

                rotadraaing = 0;
                if(positions != null) this.transform.position = positions[i].position;
            }
        }

        prevAngle = checkAngle;
    }

    private void Awake()
    {
        if (aCheck)
        {
            this.transform.position = positions[0].position;
        }
    }
}
