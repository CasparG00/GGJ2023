using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ISOPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody Rigidbody => rb = rb != null ? rb : GetComponent<Rigidbody>();

    private Vector3 wishDir;
    public float speed;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource feetAudioSource;

    private void Update()
    {
        var h = (Vector3.left - Vector3.forward).normalized * Input.GetAxisRaw("Horizontal");
        var v = (Vector3.right - Vector3.forward).normalized * Input.GetAxisRaw("Vertical");

        wishDir = (h + v).normalized;

        if (wishDir.sqrMagnitude >= 0.1f)
        {
            if (!feetAudioSource.isPlaying)
            {
                feetAudioSource.Play();
            }
        } 
        else
        {
            feetAudioSource.Stop();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = wishDir * (speed);
        animator.SetFloat("speed", wishDir.sqrMagnitude);
    }
}

