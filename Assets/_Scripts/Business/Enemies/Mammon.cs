using UnityEngine;

[RequireComponent(typeof(BasicChase)), RequireComponent(typeof(BasicAttacker))]
public class Mammon : Enemy
{

    public override void Die()
    {
        base.Die();
        GetComponent<BasicChase>().enabled = false;
        Helpers.GetWait(1);
        Destroy(gameObject); //todo pool
        print("pool yapılacak");
        //todo exp drop
    }
}
