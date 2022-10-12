using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSuelo : MonoBehaviour
{
    public static bool floor;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Suelo"))
        {
            floor = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Suelo"))
        {
            floor = false;
        }
    }
}
