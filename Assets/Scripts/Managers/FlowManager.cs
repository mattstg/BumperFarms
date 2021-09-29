using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager 
{
    #region Singleton
    private FlowManager() { }
    private static FlowManager instance = null;
    public static FlowManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FlowManager();
            }
            return instance;
        }
    }
    #endregion

}
