using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject optionPanel;
    public void OptionPanel()
    {
        //parar el tiempo en el juego
        Time.timeScale = 0;
        optionPanel.SetActive(true);

    }

    public void Continue()
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SelectMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelector");
    }

    public void StartGame()
    {


        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel1");
    }
    public void CloseGame()
    {
        Application.Quit();

    }
  
}
