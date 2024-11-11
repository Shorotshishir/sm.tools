using System;
using UnityEngine;

/// <summary>
/// Generic singleton class for MonoBehaviour-derived classes.
/// Inherit from this class to make a singleton component.
/// </summary>
/// <typeparam name="T">The type of the singleton instance</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();
    private static bool _isShuttingDown = false;

    /// <summary>
    /// The public instance of the singleton.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_isShuttingDown)
            {
                Debug.LogWarning($"[Singleton] Instance of {typeof(T)} already destroyed. Returning null.");
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindAnyObjectByType(typeof(T));

                    if (_instance == null)
                    {
                        var singletonObject = new GameObject($"{typeof(T)}");
                        _instance = singletonObject.AddComponent<T>();
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return _instance;
            }
        }
    }

    /// <summary>
    /// Initialize the singleton instance.
    /// </summary>
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        Init();
    }

    /// <summary>
    /// This works as a Awake Function for the Singleton. No need to call base.Init()
    /// 
    /// </summary>
    protected virtual void Init()
    {
        // base does nothing
    }

    private void OnApplicationQuit()
    {
        _isShuttingDown = true;
    }

    private void OnDestroy()
    {
        _isShuttingDown = true;
    }
}
