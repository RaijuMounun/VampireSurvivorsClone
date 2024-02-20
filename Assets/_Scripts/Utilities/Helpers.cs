using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    #region Camera
    //Because of the Camera.main is an expensive operation, we are caching the camera.
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
    //Every use of WaitForSeconds creates a new garbage for garbage collector to collect, so we are caching the WaitForSeconds.
    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWait(float time)
    {
        if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

        WaitDictionary[time] = new WaitForSeconds(time);
        return WaitDictionary[time];
    }
    #endregion

    //Object pooler method
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
