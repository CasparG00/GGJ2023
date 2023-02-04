using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    public GameObject UIobject;
    public Vector3 offset;
    private void OnEnable()
    {
        EventSystem<Transform>.AddListener(EventType.onUIEnter, OnEnter);
        EventSystem.AddListener(EventType.onUIExit, OnExit);
    }

    private void OnDisable()
    {
        EventSystem<Transform>.RemoveListener(EventType.onUIEnter, OnEnter);
        EventSystem.RemoveListener(EventType.onUIExit, OnExit);
    }

    private void OnEnter(Transform _transform)
    {
        UIobject.transform.position = _transform.position + offset;
        UIobject.SetActive(true);
    }

    private void OnExit()
    {
        UIobject.SetActive(false);
    }



}
