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
            var overlaps = Physics2D.OverlapCircleAll(transform.position, detectionRadius, detectionLayerMask);
            
            foreach (var overlap in overlaps)
            {
                if (overlap.gameObject == gameObject) continue;
                var slidePieceComponent = overlap.transform.GetComponent<SlidePiecePoint>();
                if (slidePieceComponent != null)
                {
                    Connected = true;
                    slidePieceComponent.Connected = true;
                }
            }
        }
    }
}
