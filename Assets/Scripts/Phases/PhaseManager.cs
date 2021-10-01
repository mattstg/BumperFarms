using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Special manager because I need keys/value pairs. It doesnt ever remove or update each one
//So not a normal manager
public class PhaseManager
{
    
    Dictionary<System.Type, IPhase> phaseDict;
    System.Type currentPhase;




    public PhaseManager()
    {
        currentPhase = typeof(GamePhase);

        phaseDict = new Dictionary<System.Type, IPhase>();
        phaseDict.Add(typeof(ContractPhase), new ContractPhase());
        phaseDict.Add(typeof(GamePhase), new GamePhase());
        phaseDict.Add(typeof(EndGamePhase), new EndGamePhase());
        phaseDict.Add(typeof(PurchasePhase), new PurchasePhase());
    }

    public void StartApp()
    {
        foreach (var kv in phaseDict)
            kv.Value.StartApp();
    }

    public void UpdateGame()
    {
        phaseDict[currentPhase].Update();
    }

    public void FixedUpdateGame()
    {
        phaseDict[currentPhase].FixedUpdate();
    }

    public void QuitApp()
    {
        foreach (var kv in phaseDict)
            kv.Value.AppQuit();
    }

    public void ChangePhase(System.Type newPhase)
    {
        if(newPhase != currentPhase)
        {
            phaseDict[currentPhase].EndPhase();
            currentPhase = newPhase;
            phaseDict[currentPhase].StartPhase();
        }
    }

}
