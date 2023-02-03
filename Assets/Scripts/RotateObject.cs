using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] RotatePuzzle rotPuzzle;

    private void Start()
    {
        rotPuzzle = GetComponentInParent<RotatePuzzle>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            rotPuzzle.isMouseDown = true;
        }
        else
        {
            rotPuzzle.isMouseDown = false;
        }

    }

    private void OnMouseExit()
    {
        rotPuzzle.isMouseDown = false;
    }
}
