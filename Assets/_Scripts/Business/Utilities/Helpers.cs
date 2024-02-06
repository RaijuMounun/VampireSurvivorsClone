using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class Helpers
{
    #region Camera
    //Camera.main pahalı olduğu için bir örneğini tutuyoruz.
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }
    #endregion


    #region WaitForSeconds
    //Her waitforseconds kullanımında garbage collector'ın toplayacağı çöp artar, burada dictionary kullanarak waitforseconds'ları tekrar tekrar kullanıyoruz.
    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWait(float time)
    {
        Debug.Log("GetWait " + time);
        if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

        WaitDictionary[time] = new WaitForSeconds(time);
        return WaitDictionary[time];
    }
    #endregion


    public static void MakePool(GameObject prefab, int poolSize, Transform parent, List<GameObject> poolList)
    {
        for (int i = 0; i < poolSize; i++)
        {
            var obj = Object.Instantiate(prefab, parent);
            obj.SetActive(false);
            poolList.Add(obj);
        }
    }

}
