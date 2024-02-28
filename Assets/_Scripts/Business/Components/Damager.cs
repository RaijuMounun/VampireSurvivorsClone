using UnityEngine;
using UnityEngine.Events;

public class Damager : MonoBehaviour
{
    [Range(0, 100)] public float damage;
    public string tagToDamage;
    [Space(20)] public UnityEvent onDamage;

    /*public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        GameObject hitObject = other.gameObject;
        TryDamageObject(hitObject);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        TryDamageObject(hitObject);
    }

    void TryDamageObject(GameObject objectToDamage)
    {
        if (!objectToDamage.CompareTag(tagToDamage)) return;
        if (!objectToDamage.TryGetComponent(out Damageable damageableObject)) return;
        damageableObject.DealDamage(damage);
        onDamage.Invoke();
    }
}
