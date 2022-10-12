using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2;
    public float jumpForce = 3;
    
    //salto mejorado
    public bool upgradeJump = true;
    public float normalJump = 0.5f;
    public float betterJump = 1f;

    //doble salto
    private bool doubleJumpOK;
    public float doubleJumpForce = 2.5f;


    Rigidbody2D rb2b;
    SpriteRenderer spr;
    Animator anim;

    void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //salto y doble salto
        if ((Input.GetKey("space") || Input.GetKey("up")))
        {
            if (CheckSuelo.floor)
            {
                doubleJumpOK = true;
                rb2b.velocity = new Vector2(rb2b.velocity.x, jumpForce);
            }
            else
            {
                if ((Input.GetKeyDown("space") || Input.GetKeyDown("up")))
                {
                    if (doubleJumpOK)
                    {
                        anim.SetBool("DobleSalto", true);
                        rb2b.velocity = new Vector2(rb2b.velocity.x, doubleJumpForce);
                        doubleJumpOK = false;
                    }
                }
            }
            

        }


        //controlar animacion salto
        if (CheckSuelo.floor == false)
        {
            anim.SetBool("Saltando", true);

        }
        else if (CheckSuelo.floor == true)
        {
            anim.SetBool("Saltando", false);
            anim.SetBool("DobleSalto", false);
            anim.SetBool("Cayendo", false);

        }
        if (rb2b.velocity.y < 0)
        {
            anim.SetBool("Cayendo", true);
        }else if (rb2b.velocity.y > 0)
        {
            anim.SetBool("Cayendo",false);
        }
    }

    private void FixedUpdate()
    {

        //movimiento + flipX de sprite
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2b.velocity = new Vector2(speed, rb2b.velocity.y);
            spr.flipX = false;
            anim.SetBool("Corriendo", true);

        }
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2b.velocity = new Vector2(-speed, rb2b.velocity.y);
            spr.flipX = true;
            anim.SetBool("Corriendo", true);
        }
        else
        {
            rb2b.velocity = new Vector2(0, rb2b.velocity.y);
            anim.SetBool("Corriendo", false);
        }


        //salto mejorado
        if (upgradeJump)
        {
            if (rb2b.velocity.y < 0)
            {
                rb2b.velocity += Vector2.up * Physics2D.gravity.y * (normalJump) * Time.deltaTime;
            }
            if (rb2b.velocity.y > 0 && !(Input.GetKey("space") || Input.GetKey("up")))
            {
                rb2b.velocity += Vector2.up * Physics2D.gravity.y * (betterJump) * Time.deltaTime;
            }
        }

    }
}
