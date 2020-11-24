using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoUi : MonoBehaviour
{
    private static demoUi instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            //gm.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
/*    public static demoUi GetInstance()
    {
        return instance;
    }*/
}
