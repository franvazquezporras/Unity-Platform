using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPosX, checkPointPosY;
    public Animator anim;
    public GameObject[] lifes;
    private int life;
    
    void Start()
    {
        life = lifes.Length;

        if (PlayerPrefs.GetFloat("checkPointPosX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPosX"), PlayerPrefs.GetFloat("checkPointPosY")));
        } 
    }

    private void CheckLifes()
    {
        if (life < 1)
        {
            Destroy(lifes[0].gameObject);
            anim.Play("PlayerHit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (life < 2)
        {
            Destroy(lifes[1].gameObject);
            anim.Play("PlayerHit");
        }
        else if (life < 3)
        {
            Destroy(lifes[2].gameObject);
            anim.Play("PlayerHit");
        }
    }
    public void CheckPoint(float x, float y)
    {
        //Guardamos la info del checkpoint
        PlayerPrefs.SetFloat("checkPointPosX",x);
        PlayerPrefs.SetFloat("checkPointPosY", y);
    }


    public void DamageToPlayer()
    {
        life--;
        CheckLifes();
    }
   
}
