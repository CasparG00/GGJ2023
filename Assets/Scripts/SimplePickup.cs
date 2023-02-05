using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    public ItemType itemType;
    private bool hasEntered;

    private void OnTriggerEnter(Collider other)
    {
        hasEntered = true;
        EventSystem<WorldMessage>.InvokeEvent(EventType.onUIEnter, new WorldMessage(transform, "PRESS E"));
    }

    private void OnTriggerExit(Collider other)
    {
        hasEntered = false;
        EventSystem.InvokeEvent(EventType.onUIExit);
    }

    private void Update()
    {
        if (!hasEntered) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Inventory.AddItem(itemType, 1);
            Destroy(gameObject);
            EventSystem.InvokeEvent(EventType.onUIExit);
        }
    }
}
