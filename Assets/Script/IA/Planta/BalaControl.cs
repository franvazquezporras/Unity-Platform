using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControl : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 2;
    public bool leftDirection;

    
    private void Start()
    {
     
        Destroy(gameObject, lifeTime);
    }

    public void Direction(bool direction)
    {
        leftDirection = direction;
    }

    private void Update()
    {
        if (leftDirection)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
