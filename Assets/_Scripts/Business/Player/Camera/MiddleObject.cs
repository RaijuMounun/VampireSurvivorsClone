using UnityEngine;

public class MiddleObject : MonoBehaviour
{
    [SerializeField] Transform _player, _mouseObj;
    [SerializeField, Tooltip("Lower = Closer to the player, vice versa"), Range(0f, 1f)]
    float _speed = 0.3f;

    // This object is between the player and the mouse object, for camera to look.
    void Update() => transform.position = Vector3.Lerp(_player.position, _mouseObj.position, _speed);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
