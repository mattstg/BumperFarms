using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePhase : IPhase, IManagedItem
{
    public void StartApp() { }
    public void StartPhase() { }
    public void Update() { }
    public void FixedUpdate() { }
    public void EndPhase() { }
    public void AppQuit() { }

    public void AddedToManager() { }
    public void RemovedFromManager() { }
}