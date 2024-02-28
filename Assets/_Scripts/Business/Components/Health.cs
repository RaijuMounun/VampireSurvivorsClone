using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Damageable))]
public class Health : MonoBehaviour
{
    [Range(0, 100)] public float maxHealth;
    [Range(0, 100)] public float currentHealth;
    public UnityEvent onHealthZero;
    public bool isDead;

    private void Start() => currentHealth = maxHealth;

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth > 0) return;
        onHealthZero.Invoke();
        isDead = true;
    }
}
