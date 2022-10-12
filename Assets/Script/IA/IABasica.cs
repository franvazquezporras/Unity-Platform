using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasica : Damage
{
    
    public float speed = 0.5f;
    private float waitTime;
    public float startWaitTime = 2;
    public Transform[] targets;

    private int point = 0;
    private Vector2 actualPoistion;



    void Start()
    {
        waitTime = startWaitTime;        
    }


    void Update()
    {
        StartCoroutine(MovimientoEnemigo());
        transform.position = Vector2.MoveTowards(transform.position, targets[point].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targets[point].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                //recorre todos los puntos del array
                if (targets[point] != targets[targets.Length - 1])
                {
                    point++;
                }
                else
                {
                    point = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator MovimientoEnemigo()
    {
        actualPoistion = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPoistion.x)
        {
            spr.flipX = true;
            anim.SetBool("descansando", false);
        }
        else if(transform.position.x < actualPoistion.x)
        {
            spr.flipX = false;
            anim.SetBool("descansando", false);
        }else if(transform.position.x == actualPoistion.x)
        {
            anim.SetBool("descansando", true);
        }
    }
}
