using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    public ItemType itemType;
    public bool hasEntered;

    private void OnTriggerEnter(Collider other)
    {
        hasEntered = true;
        EventSystem<Transform>.InvokeEvent(EventType.onUIEnter, transform);
    }

    private void OnTriggerExit(Collider other)
    {
        hasEntered = false;
    }

    private void Update()
    {
        if (!hasEntered) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Inventory.AddItem(itemType, 1);
            EventSystem.InvokeEvent(EventType.onUIExit);
            Destroy(gameObject);
        }
    }
}
