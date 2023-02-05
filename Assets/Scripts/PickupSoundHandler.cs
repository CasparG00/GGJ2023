using System;
using UnityEngine;

public class PickupSoundHandler : MonoBehaviour
{
    [SerializeField] private PickupSound[] sounds;

    [Serializable]
    public class PickupSound
    {
        public ItemType type;
        public AudioClip clip;
    }

    private void OnEnable()
    {
        //EventSystem<ItemType>.AddListener(EventType.onPickupItem, OnPickupItem);
    }

    private void OnDisable()
    {
       
    }

    private void OnPickupItem()
    {

    }
}
