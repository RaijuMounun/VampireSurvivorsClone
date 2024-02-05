using UnityEngine;

public class Weapon : MonoBehaviour
{
    Transform playerMouse;
    private void Start()
    {
        playerMouse = PlayerMouse.Instance.transform;
    }




    private void Update()
    {
        transform.up = playerMouse.position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * 10);
    }
}
