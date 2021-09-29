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

    Dictionary<int, InputPkg> playerInput;

    public void Initialize(int numOfPlayers)
    {
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

        public InputPkg(int _pid)
        {
            pid = _pid;
        }
        public void UpdateInput()
        {

        }
    }
}
