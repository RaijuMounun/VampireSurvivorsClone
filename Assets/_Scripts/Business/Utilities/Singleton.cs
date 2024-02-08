using UnityEngine;

public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{//Making a static instance
    public static T Instance { get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{//Making that instance a singleton
    protected override void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        base.Awake();
    }
}

public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{//Making that singleton persistent along the scenes
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}

