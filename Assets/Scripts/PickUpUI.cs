using System;
using TMPro;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    public TextMeshProUGUI UIobject;
    public Vector3 offset;
    private void OnEnable()
    {
        EventSystem<WorldMessage>.AddListener(EventType.onUIEnter, OnEnter);
        EventSystem.AddListener(EventType.onUIExit, OnExit);
    }

    private void OnDisable()
    {
        EventSystem<WorldMessage>.RemoveListener(EventType.onUIEnter, OnEnter);
        EventSystem.RemoveListener(EventType.onUIExit, OnExit);
    }

    private void OnEnter(WorldMessage message)
    {
        UIobject.transform.position = message.target.position + offset;
        UIobject.text = message.message;
        UIobject.gameObject.SetActive(true);
    }

    private void OnExit()
    {
        UIobject.gameObject.SetActive(false);
    }
}

[Serializable]
public class WorldMessage
{
    public Transform target;
    public string message;

    public WorldMessage(Transform target, string message)
    {
        this.target = target;
        this.message = message;
    }
}
