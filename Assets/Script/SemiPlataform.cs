using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiPlataform : MonoBehaviour
{
    private PlatformEffector2D effector;

    public float startWait;//tiempo que tarda en poder bajar de la plataforma(evitar que sea instantaneo)

    private float time;
   
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

    }

   
    void Update()
    {
        //reset tiempo espera
        if (Input.GetKeyUp("down")|| Input.GetKeyUp("s"))
        {
            time = startWait;

        }


        //bajar de la plataforma
        if(Input.GetKey("down") || Input.GetKey("s"))
        {
            if (time <= 0)
            {
                effector.rotationalOffset = 180f;
                time = startWait;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }

        //saltar de la plataforma
        if (Input.GetKey("space") || Input.GetKey("up"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
