using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SeleccionNivel : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool doorOK = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            doorOK = true;
        }   
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        doorOK = false;
    }


    private void Update()
    {
        if (doorOK && Input.GetKey("w"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
