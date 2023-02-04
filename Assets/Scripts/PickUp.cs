using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickUp : MonoBehaviour
{
    public GameObject itemPrefab;
    [SerializeField] private Sprite displaySprite;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer SpriteRenderer => spriteRenderer = spriteRenderer == null ? GetComponent<SpriteRenderer>() : spriteRenderer;

    private void Awake()
    {
        SpriteRenderer.sprite = displaySprite;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventSystem<GameObject>.InvokeEvent(EventType.onPickupItem, itemPrefab);
        }

        Destroy(gameObject);
    }
}
