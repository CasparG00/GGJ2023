using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupLetter : MonoBehaviour
{
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
            Destroy(gameObject);
            EventSystem.InvokeEvent(EventType.onUIExit);
            SceneManager.LoadScene(2);
        }
    }
}
