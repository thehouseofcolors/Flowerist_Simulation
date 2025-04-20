using UnityEngine;

public class MasterManager : Singleton<MasterManager>
{
    // Static references to all managers
    public static UIManager UIManager { get; private set;}
    public static DataManager Data { get; private set; }
    public static SceneLoader SceneLoader { get; private set; }
    public static EventManager Events { get; private set; }

    protected override void Awake() 
    {
        

        // Initialize all managers
        UIManager = GetComponentInChildren<UIManager>();
        
        Data = GetComponentInChildren<DataManager>();
        SceneLoader = GetComponentInChildren<SceneLoader>();
        Events = GetComponentInChildren<EventManager>();

        // Optional: Initialize in a specific order if dependencies exist
        // Data.Initialize();
        
    }
}