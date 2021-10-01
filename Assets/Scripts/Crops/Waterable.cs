using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waterable : MonoBehaviour
{
    public float maxWaterTimeHold = 120;            //When watered, this countdown goes to this
    public float timeRemainBeforeWaterWarning = 45;       //When timer remaining reaches this, a warning appears
    public float timeRemainBeforeDireWaterWarning = 10;   //When timer remaining reaches this, a dire warning apperas

    public bool canOverWater = false;               //Can only water after warning appears, or it dies as well
    bool warningEventStarted;
    bool direWarningEventStarted;
    bool deathCalled;
    float timeOfLastWatering;


    public UnityEvent wasWateredEvent;
    public UnityEvent warningEventStart;
    public UnityEvent direWarningEventStart;
    public UnityEvent deathEvent;


    float TimeOfWarning => timeOfLastWatering + (maxWaterTimeHold - timeRemainBeforeWaterWarning);
    float TimeOfDireWarning => timeOfLastWatering + (maxWaterTimeHold - timeRemainBeforeDireWaterWarning);

    float TimeOfDeath => timeOfLastWatering + maxWaterTimeHold;

    private void Awake()
    {
        timeOfLastWatering = Time.time;
    }

    public void Water()
    {
        if(canOverWater && Time.time < TimeOfWarning)
        {
            deathEvent?.Invoke();
        }
        else
        {
            wasWateredEvent?.Invoke();
            warningEventStarted = false;
            direWarningEventStarted = false;
        }


    }

    public void Update()
    {
        if(Time.time > TimeOfWarning && !warningEventStarted)
        {
            warningEventStarted = true;
            warningEventStart?.Invoke();
        }

        if (Time.time > TimeOfDireWarning && !direWarningEventStarted)
        {
            direWarningEventStarted = true;
            direWarningEventStart?.Invoke();
        }

        if(Time.time > TimeOfDeath && !deathCalled)
        {
            deathCalled = true;
            deathEvent?.Invoke();
        }
    }


}
