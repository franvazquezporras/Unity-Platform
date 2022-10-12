using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitTime;
    const float coolDownAtack = 3;
    public Animator anim;
    public GameObject bullet;
    public Transform spawnBullet;
    public bool directionBullet;

    private void Start()
    {
        waitTime = coolDownAtack;
    }

    private void Update()
    {
        if (waitTime <= 0)
        {
            waitTime = coolDownAtack;
            anim.Play("ATTACK");
            Invoke("Shoot", 0.5f);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        GameObject newBullet;

        newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        newBullet.GetComponent<BalaControl>().Direction(directionBullet);
    }
}
