using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unlike other managers, can access during any phase or scene.
//Does not add or remove elements
public class InputManager 
{
    #region Singleton
    private InputManager() { }
    private static InputManager instance = null;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }
    }
    #endregion
    Rewired.InputManager rewiredInputManager;
    Dictionary<int, InputPkg> playerInput;

    public void Initialize(int numOfPlayers)
    {
        rewiredInputManager = GameObject.FindObjectOfType<Rewired.InputManager>();
        playerInput = new Dictionary<int, InputPkg>();
        for(int i =0; i < numOfPlayers; i++)
        {
            playerInput.Add(i, new InputPkg(i));
        }
    }

    public void Update()
    {
        foreach(var kv in playerInput)
        {
            kv.Value.UpdateInput();
        }

    }


    public void FixedUpdate()
    {

    }

    public InputPkg GetPlayerInput(int pid)
    {
        return playerInput[pid];
    }


    public class InputPkg
    {
        int pid;
        Rewired.Player rplayer;

        public Vector2 dirPressed;
        public bool pickupDropPressed;
        public bool usePressed;

        public InputPkg(int _pid)
        {
            pid = _pid;
            rplayer  = Rewired.ReInput.players.GetPlayer(pid);
        }

        public void UpdateInput()
        {
            dirPressed = new Vector2(rplayer.GetAxis("Horz"), rplayer.GetAxis("Vert"));
            pickupDropPressed = rplayer.GetButtonDown("PickupDrop");
            usePressed = rplayer.GetButton("UseItem");
        }
    }
}
