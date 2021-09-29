using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagedItem 
{
    void AddedToManager();
    void RemovedFromManager();

    void Update();
    void FixedUpdate();
}
