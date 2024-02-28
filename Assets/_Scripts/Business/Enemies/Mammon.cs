using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BasicChase)), RequireComponent(typeof(BasicAttacker))]
public class Mammon : Enemy
{

    public override void Die()
    {
        base.Die();
        StartCoroutine(DieAnim());
    }
    IEnumerator DieAnim()
    {
        GetComponent<BasicChase>().enabled = false;
        yield return Helpers.GetWait(1.7f);
        Destroy(gameObject);
        print("pool yapılacak");
    }
}
