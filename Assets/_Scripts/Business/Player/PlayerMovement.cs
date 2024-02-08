using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] SO_PlayerCharacters _playerCharacterSO;
    Rigidbody _rb;
    PlayerMouse _playerMouse;

    public event Action<float> OnPlayerMove;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMouse = PlayerMouse.Instance;
    }

    private void FixedUpdate()
    {
        //Movement
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rb.velocity = direction * _playerCharacterSO.Speed;
        //Event
        if (direction != Vector3.zero) OnPlayerMove?.Invoke(direction.z);
        //LookAtMouse
        transform.LookAt(_playerMouse.transform);
    }


}
