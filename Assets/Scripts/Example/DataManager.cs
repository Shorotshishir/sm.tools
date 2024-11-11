using UnityEngine;

/// <summary>
/// Attach it to a gameobject
/// </summary>
public class DataManager : Singleton<DataManager>
{
    protected override void Init()
    {
        // base.Init();
        Debug.Log($"{GetType()} Initialized");
    }
}
