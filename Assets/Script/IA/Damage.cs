using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Collider2D col2D;
    public Animator anim;
    public SpriteRenderer spr;
    public GameObject deathParticle;
    public float jumpForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LostLife();
            CheckLifes();
        }
    }

    public void LostLife()
    {
        lifes--;
        anim.Play("Hit");
    }

    public void CheckLifes()
    {
        if (lifes == 0)
        {
            deathParticle.SetActive(true);
            spr.enabled = false;
            Invoke("KillEnemy", 0.2f);
        }
    }


    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
