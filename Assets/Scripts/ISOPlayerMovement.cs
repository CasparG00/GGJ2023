using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ISOPlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterController CharacterController => characterController = characterController != null ? characterController : GetComponent<CharacterController>();

    public float speed;

    public void Update()
    {
        var h = (Vector3.right - Vector3.forward).normalized * Input.GetAxisRaw("Horizontal");
        var v = (Vector3.right - Vector3.back).normalized * Input.GetAxisRaw("Vertical");

        var wishDir = (h + v).normalized;

        CharacterController.Move(wishDir * (speed * Time.deltaTime));
    }
}

