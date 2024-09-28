using UnityEngine;
public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    protected static volatile T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType(typeof(T)) as T;
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        EnsureSingletonInstance();
    }
    private void EnsureSingletonInstance()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
