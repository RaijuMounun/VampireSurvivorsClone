using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    //This object follows the mouse.
    private void Update()
    {
        transform.position = FollowMouse();
    }
    Vector3 FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 25;
        return Helpers.Camera.ScreenToWorldPoint(mousePos);
    }
}
