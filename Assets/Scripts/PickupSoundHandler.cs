using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickupSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private PickupSound[] sounds;

    [Serializable]
    public class PickupSound
    {
        public ItemType type;
        public AudioClip clip;
    }

    private Dictionary<ItemType, AudioClip> audioDictionary;
    private Dictionary<ItemType, AudioClip> AudioDictionary => audioDictionary ??= sounds.ToDictionary(x => x.type, y => y.clip);

    [SerializeField] private AudioClip barricadeDestroyedSound;

    private void OnEnable()
    {
        EventSystem<ItemType>.AddListener(EventType.onPickupItem, OnPickupItem);
        EventSystem.AddListener(EventType.barricadeDestroyed, BarricadeDestroyed);
    }

    private void OnDisable()
    {
        EventSystem<ItemType>.RemoveListener(EventType.onPickupItem, OnPickupItem);
        EventSystem.RemoveListener(EventType.barricadeDestroyed, BarricadeDestroyed);
    }

    private void BarricadeDestroyed()
    {
        source.clip = barricadeDestroyedSound;
        source.Play();
    }

    private void OnPickupItem(ItemType type)
    {
        source.clip = AudioDictionary[type];
        source.Play();
    }
}
