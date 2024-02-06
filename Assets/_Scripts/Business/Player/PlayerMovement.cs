using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] SO_PlayerCharacters _playerCharacterSO;
    [SerializeField] Rigidbody _rb;

    private void FixedUpdate()
    {
        //Movement
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rb.velocity = direction * _playerCharacterSO.Speed;
    }
}
