using UnityEngine;

public class DoorSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource.Play();
    }
}
