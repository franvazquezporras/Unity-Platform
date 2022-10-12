using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Vector2 parallaxEfectMultiplier;
    private Transform cameraPosition;
    private Vector3 lastPositionCamera;

    private void Start()
    {
        cameraPosition = Camera.main.transform;
        lastPositionCamera = cameraPosition.position;

    }

    private void LateUpdate()
    {
        Vector3 move = cameraPosition.position - lastPositionCamera;
        transform.position += new Vector3(move.x * parallaxEfectMultiplier.x, move.y * parallaxEfectMultiplier.y);
        lastPositionCamera = cameraPosition.position;
    }
}
