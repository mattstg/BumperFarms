using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will contain all persistant data needed to be saved between rounds. Like contracts, $, items, etc
public class PersistantData
{
    #region Singleton
    private PersistantData() { }
    private static PersistantData instance = null;
    public static PersistantData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PersistantData();
            }
            return instance;
        }
    }
    #endregion

    public void InitializePersistantData()
    {

    }

}
