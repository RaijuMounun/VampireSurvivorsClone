using UnityEngine;

public class PlayerMouse : PersistentSingleton<PlayerMouse>
{
    //This object follows the mouse.
    private void Update() => transform.position = MousePosition();
    Vector3 MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 25;
        return Helpers.Camera.ScreenToWorldPoint(mousePos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
