using System.Collections;
using UnityEngine;

public class BasicAttacker : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float damage = 10;
    [SerializeField, Range(0, 5)] float attackCooldown = 1;
    [Space, SerializeField] bool isAttacking;
    GameObject objectToAttack;
    [SerializeField] bool canAttack = true;


    private void Update()
    {
        if (isAttacking) AttackSeq();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        objectToAttack = other.gameObject;
        isAttacking = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isAttacking = false;
        objectToAttack = null;
    }
    public void AttackSeq()
    {
        if (!canAttack) return;
        if (objectToAttack == null) return;
        Attack(objectToAttack);
        StartCoroutine(AttackCooldown());
    }
    void Attack(GameObject objectToDamage)
    {
        if (!objectToDamage.TryGetComponent(out Damageable damageableObject)) return;
        damageableObject.DealDamage(damage);
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return Helpers.GetWait(attackCooldown);
        canAttack = true;
    }
}
