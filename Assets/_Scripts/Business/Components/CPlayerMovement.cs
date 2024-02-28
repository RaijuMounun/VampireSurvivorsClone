using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class CPlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody rb;
    public UnityEvent<float> OnPlayerMove;

    private void Start() => rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        //Movement
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = direction * moveSpeed;
        //Event
        if (direction != Vector3.zero) OnPlayerMove?.Invoke(direction.z);
    }
}
