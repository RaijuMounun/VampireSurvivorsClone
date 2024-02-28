using UnityEngine;

public class BasicChase : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float _moveSpeed = 5f;
    [SerializeField, Range(0, 10)] float _rotationSpeed = 5f;
    [SerializeField, Range(0, 10)] float stopDist = 1f;
    Transform _target;


    private void Start()
    {
        _target = Player.Instance.transform;
    }
    private void Update() => ChasePlayer();

    public void ChasePlayer()
    {
        if (_target == null) return;
        if (Vector3.Distance(transform.position, _target.position) < stopDist) return;
        var dir = _target.position - transform.position;
        transform.forward = Vector3.MoveTowards(transform.forward, dir, _rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, _moveSpeed * Time.deltaTime);

    }
}
