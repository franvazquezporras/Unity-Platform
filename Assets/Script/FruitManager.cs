using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelclear;

    //public GameObject transition;

    public Text totalFruits;
    public Text fruitsRecolected;

    private static int fruitOfLevel;
    public GameController levelControl;
    

    private void Start()
    {
        
        fruitOfLevel = transform.childCount;
        levelControl.Unlock();
        Time.timeScale = 1;
    }



    private void Update()
    {
        NumberOfFruitsRecolected();
        totalFruits.text = fruitOfLevel.ToString();
        fruitsRecolected.text = transform.childCount.ToString();
    }



    public void NumberOfFruitsRecolected()
    {
        
        if (transform.childCount == 0)
        {
            
            levelclear.gameObject.SetActive(true);
            //transition.SetActive(true);
            
            //inicia el siguiente nivel 5 segundos despues de mostrar el cartel de victoria
            Invoke("ChanceScene", 2f);
        }
    }

    public void ChanceScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
