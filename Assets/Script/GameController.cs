using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static int unlockedLevels;
    public int actualLevel;
    public Collider2D[] levels;
    CargarYGuardar saveDates;

    private void Awake()
    {
        saveDates = GetComponent<CargarYGuardar>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelSelector")
        {
            saveDates.Save();
            ActualiceLevels();
        }
    }
    public void Unlock()
    {
        if (unlockedLevels < actualLevel)
        {
            unlockedLevels = actualLevel;
            actualLevel++;
        }
    }

    public void ActualiceLevels()
    {
        for(int i =0; i <= unlockedLevels; i++){

            levels[i].enabled = true;
        }
    }

   
}
