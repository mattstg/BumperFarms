using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    PhaseManager phaseManager;
    // Start is called before the first frame update
    void Start()
    {
        PersistantData.Instance.InitializePersistantData();

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
}
