using UnityEngine;

public class DragManager : MonoBehaviour
{
    private Transform dragTransform;
    private Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                dragTransform = hit.transform;

                offset = dragTransform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragTransform = null;
        }

        if (dragTransform != null)
        {
            dragTransform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
