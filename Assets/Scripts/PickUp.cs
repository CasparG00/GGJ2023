using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickUp : MonoBehaviour
{
    public GameObject itemPrefab;
    [SerializeField] private Sprite displaySprite;

    public bool hasEntered;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer SpriteRenderer => spriteRenderer = spriteRenderer == null ? GetComponent<SpriteRenderer>() : spriteRenderer;

    private void Awake()
    {
        SpriteRenderer.sprite = displaySprite;
    }

    private void Update()
    {
        if (!hasEntered) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventSystem<GameObject>.InvokeEvent(EventType.onPickupItem, itemPrefab);
            EventSystem.InvokeEvent(EventType.onUIExit);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasEntered = true;
        EventSystem<Transform>.InvokeEvent(EventType.onUIEnter, transform);
    }

    private void OnTriggerExit(Collider other)
    {
        hasEntered = false;
        EventSystem.InvokeEvent(EventType.onUIExit);
    }
}
