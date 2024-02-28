using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    Health health;

    private void Start() => health = GetComponent<Health>();

    public void DealDamage(float damageAmount) => health.DecreaseHealth(damageAmount);
}
