using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSingleton : MonoBehaviour
{
    public static CamaraSingleton singleton;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
//        DontDestroyOnLoad(gameObject);
    }

}
