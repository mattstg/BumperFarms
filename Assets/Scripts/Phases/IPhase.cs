using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhase
{
    void StartApp();
    void StartPhase();
    void FixedUpdate();
    void Update();
    void EndPhase();
    void AppQuit();

}
