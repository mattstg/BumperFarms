using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Unlike other managers, can access during any phase or scene.
//Does not add or remove elements
public class InputToEvents : MonoBehaviour 
{
    public int pid;
    Rewired.Player rplayer;

    public V2EventSys moveDirUpdate; //Every update sent
    public V2EventSys FU_moveDirUpdate; //Every update sent
    public UnityEvent pickupPressed;
    public UnityEvent useItemPressed;

    public Vector2 dirPressed { get; private set; }
    public bool pickupDropPressed { get; private set; }
    public bool usePressed { get; private set; }

    public void Awake()
    {
        rplayer = Rewired.ReInput.players.GetPlayer(pid);
    }

    public void Update()
    {
        dirPressed = new Vector2(rplayer.GetAxis("Horz"), rplayer.GetAxis("Vert"));
        pickupDropPressed = rplayer.GetButtonDown("PickupDrop");
        usePressed = rplayer.GetButtonDown("UseItem");

        moveDirUpdate?.Invoke(dirPressed);

        if (pickupDropPressed) pickupPressed?.Invoke();
        if (usePressed) useItemPressed?.Invoke();
    }

    public void FixedUpdate()
    {
        dirPressed = new Vector2(rplayer.GetAxis("Horz"), rplayer.GetAxis("Vert"));
        FU_moveDirUpdate?.Invoke(dirPressed);
    }
}
