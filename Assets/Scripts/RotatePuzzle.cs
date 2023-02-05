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
    public int i;
    public int amount;

    public GameObject finishObj;
    public GameObject krank;

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
                if (i >= amount)
                {
                    krank.gameObject.SetActive(false);
                    finishObj.gameObject.SetActive(true);
                }
                if (i >= amount) return;
                Destroy(items[i].gameObject);
                knopjes[i].SetActive(true);
                i++;
                if (i >= amount)
                {
                    krank.gameObject.SetActive(false);
                    finishObj.gameObject.SetActive(true);
                }
                if (i >= amount) return;
                items[i].SetActive(true);
                if (i >= amount)
                {
                    krank.gameObject.SetActive(false);
                    finishObj.gameObject.SetActive(true);
                }
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
