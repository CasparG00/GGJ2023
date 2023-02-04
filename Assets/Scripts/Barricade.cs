using System;
using System.Linq;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public RequiredMaterials[] requiredMaterials;
    
    [Serializable]
    public class RequiredMaterials
    {
        public ItemType type;
        public int amount;
    }

    private bool hasEntered;

    private void OnTriggerEnter(Collider other)
    {
        hasEntered = true;
        EventSystem<WorldMessage>.InvokeEvent(EventType.onUIEnter, new WorldMessage(transform, "PRESS E TO REMOVE"));
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
            if (requiredMaterials.Any(mat => Inventory.CheckItem(mat.type) < mat.amount))
            {
                EventSystem<WorldMessage>.InvokeEvent(EventType.onUIEnter, new WorldMessage(transform, "NOT ENOUGH MATERIALS"));
                return;
            }

            foreach (var mat in requiredMaterials)
            {
                Inventory.GetItem(mat.type, mat.amount);
            }

            EventSystem.InvokeEvent(EventType.onUIExit);
            Destroy(gameObject);
        }
    }
}
