using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static MainScript Instance { get; private set; }

    const int numOfPlayers = 2;
    [HideInInspector] public PhaseManager phaseManager;


    //Global Managers
    [HideInInspector] public IgnoreColiHelper ignoreColiHelper;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Somehow Awake for mainscript called twice, did you reload scene?");

        Instance = this;
    }

    void Start()
    {
        
        phaseManager = new PhaseManager();
        phaseManager.StartApp();

    }

    // Update is called once per frame
    void Update()
    {
        phaseManager.UpdateGame();
    }

    private void FixedUpdate()
    {
        phaseManager.FixedUpdateGame();
    }


    private void InitializeGlobalManagers()
    {
        PersistantData.Instance.InitializePersistantData();
        ignoreColiHelper.Initialize();
    }
    private void UpdateGlobalManagers()
    {
        ignoreColiHelper.Update();
    }
}
