using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Animator Animator => animator = animator == null ? GetComponent<Animator>() : animator;

    public void OnPlayerMove(float speed)
    {
        Animator.SetFloat("speed", speed);
    }
}
