using UnityEngine;

public class ExpMagnet : MonoBehaviour
{
    SphereCollider _col;
    [Range(0, 50)] public float magnetRange;


    private void Awake()
    {
        _col = GetComponent<SphereCollider>();
        _col.isTrigger = true;
        _col.radius = magnetRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<ExpOrb>(out var expOrb)) return;
        expOrb.isMagnetized = true;
    }

}
