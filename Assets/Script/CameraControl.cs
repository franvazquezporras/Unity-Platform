using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    public GameObject seguir;
    public Vector2 minCamaraPosition, maxCamaraPosition;
    public float suavizarTiempo;

    private Vector2 velocidad;
    private float posX, posY;

    private void Awake()
    {
        seguir = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if(Application.loadedLevelName == "LevelSelector")
        {
             posX = 0;
             posY = 0;
        }
        else
        {
             posX = Mathf.SmoothDamp(transform.position.x, seguir.transform.position.x, ref velocidad.x, suavizarTiempo);
             posY = Mathf.SmoothDamp(transform.position.y, seguir.transform.position.y, ref velocidad.y, suavizarTiempo);
        }
        

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamaraPosition.x, maxCamaraPosition.x),
            Mathf.Clamp(posY, minCamaraPosition.y, maxCamaraPosition.y),
            transform.position.z);


    }
}
