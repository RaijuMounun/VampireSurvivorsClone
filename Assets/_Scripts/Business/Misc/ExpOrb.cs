using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expValue;
    public bool isMagnetized;

    private void Update()
    {
        //if magnetized, move towards player
        if (!isMagnetized) return;
        transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, 10 * Time.deltaTime);

        //if reached player, add exp and destroy
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) > 1f) return;
        Destroy(gameObject);
        Player.Instance.AddExp(expValue);
    }
}
