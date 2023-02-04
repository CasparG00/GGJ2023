using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Transform dragTransform;
    private Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.transform.GetComponent<SlidePiece>() != null)
                {
                    dragTransform = hit.transform;

                    offset = dragTransform.position - cam.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragTransform = null;
        }

        if (dragTransform != null)
        {
            dragTransform.position = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
