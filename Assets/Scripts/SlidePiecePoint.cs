using UnityEngine;

public class SlidePiecePoint : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 0.5f;
    [SerializeField] private LayerMask detectionLayerMask;

    public bool Connected
    {
        get; private set; 
    }
    private void Update()
    {
        if (!Connected)
        {
            var overlap = Physics2D.OverlapCircle(transform.position, detectionRadius, detectionLayerMask);
            var slidePieceComponent = overlap.transform.GetComponent<SlidePiecePoint>();
            if (slidePieceComponent != null)
            {
                Connected = true;
                slidePieceComponent.Connected = true;
            }
        }

        EventSystem<GameObject>.InvokeEvent(EventType.onPickupItem, null);
    }
}
