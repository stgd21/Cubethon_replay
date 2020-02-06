using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAgent : MonoBehaviour
{

    private float maxSpeed = 0.1f;
    private float maxRotation = 20f;
    private float half_t_sq;

    //Vector to seek/flee in determined every frame
    private Vector3 directionToMove;
    private Vector3 velocity = new Vector3(0, 0.1f, 0);

    private void Update()
    {
        //Face a random direction not too far away from current vector
        transform.Rotate(0, RandomBinomial() * maxRotation, 0);
        //Go forward automatically
        directionToMove = transform.forward * maxSpeed;
        transform.position += directionToMove;
    }

    private float RandomBinomial()
    {
        return Random.value - Random.value;
    }
}
