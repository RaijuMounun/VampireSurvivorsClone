using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCanvas : PersistentSingleton<BulletCanvas>
{
    public TextMeshProUGUI bulletCountText;
    public void UpdateBulletCount(int currentAmmo, int maxAmmo) => bulletCountText.text = currentAmmo + " / " + maxAmmo;
}
