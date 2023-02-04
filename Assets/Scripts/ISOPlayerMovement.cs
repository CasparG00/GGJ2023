using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ISOPlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Rigidbody Rigidbody => rigidbody = rigidbody != null ? rigidbody : GetComponent<Rigidbody>();

    private Vector3 wishDir;
    public float speed;

    public UnityEvent<float> onMove;

    private void Update()
    {
        var h = (Vector3.left - Vector3.forward).normalized * Input.GetAxisRaw("Horizontal");
        var v = (Vector3.right - Vector3.forward).normalized * Input.GetAxisRaw("Vertical");

        wishDir = (h + v).normalized;
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = wishDir * (speed);

        onMove.Invoke(wishDir.sqrMagnitude);
    }
}

