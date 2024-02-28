using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    Animator animator;
    readonly string forwardTrigger = "TForward", backwardsTrigger = "TBackwards";

    private void Awake() => animator = GetComponent<Animator>();

    public void OnPlayerMove(float directionX)
    {
        var trigger = directionX > 0 ? forwardTrigger : backwardsTrigger;
        animator.SetTrigger(trigger);

        var triggerToReset = trigger == forwardTrigger ? backwardsTrigger : forwardTrigger;
        animator.ResetTrigger(triggerToReset);
    }
}
