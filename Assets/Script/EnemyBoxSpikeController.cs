using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxSpikeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<PlayerRespawn>().DamageToPlayer();
        }
    }
}
