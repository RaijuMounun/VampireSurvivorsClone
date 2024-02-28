using UnityEngine;

[RequireComponent(typeof(Damageable))]
public abstract class Enemy : MonoBehaviour
{
    public Animator animator;
    Collider _col;
    [Range(0, 100)] public float damage = 10;
    [SerializeField, Range(0, 100)] int expValue = 10;
    [SerializeField] ExpOrb expOrbPrefab;

    private void Awake()
    {
        _col = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }


    //Disable collider, spawn exp orb, play death animation
    public virtual void Die()
    {
        animator.SetTrigger("isDead");
        _col.enabled = false;
        var expOrb = Instantiate(
            expOrbPrefab,
            transform.position + new Vector3(0, 0.5f, 0),
            Quaternion.identity);
        expOrb.expValue = expValue;
    }
}
