using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public UnityEvent onFire;

    void Update()
    {
        if (Input.GetButton("Fire1")) onFire.Invoke();
    }
}
