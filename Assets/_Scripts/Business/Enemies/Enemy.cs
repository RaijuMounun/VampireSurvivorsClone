using UnityEngine;

[RequireComponent(typeof(Damageable))]
public abstract class Enemy : MonoBehaviour
{
    public Animator animator;
    Collider _col;
    [Range(0, 100)] public float damage = 10;
    [SerializeField, Range(0, 100)] float expValue = 10;

    private void Awake()
    {
        _col = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }


    public virtual void Die()
    {
        //todo animator.SetTrigger("Die");
        _col.enabled = false;
    }
}
