using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    //Subject to observe
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] Animator animator;
    string forwardTrigger = "TForward", backwardsTrigger = "TBackwards";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null) playerMovement.OnPlayerMove += OnPlayerMove; //Subscribe
    }

    void OnPlayerMove(float directionX)
    {
        var trigger = directionX > 0 ? forwardTrigger : backwardsTrigger;
        animator.SetTrigger(trigger);

        var triggerToReset = trigger == forwardTrigger ? backwardsTrigger : forwardTrigger;
        animator.ResetTrigger(triggerToReset);
    }

    private void OnDestroy()
    {
        if (playerMovement != null) playerMovement.OnPlayerMove -= OnPlayerMove; //Unsubscribe
    }
}
