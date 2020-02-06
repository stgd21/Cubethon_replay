using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoothing : MonoBehaviour
{
    Vector3 position;
    float orientation;
    Vector3 velocity;
    float rotation;
    Vector3 linear;
    float angular = 0.1f;
    float half_t_sq;
    float maxSpeed = 5f;
    float maxRotation = 20f;

    private void Start()
    {
        velocity = transform.forward * maxSpeed;
    }

    private void Update()
    {
        linear = transform.forward * maxSpeed;
        orientation = transform.rotation.y;
        half_t_sq = (float)0.5 * Time.deltaTime * Time.deltaTime;
        transform.position += velocity * Time.deltaTime + linear * half_t_sq;
        transform.rotation *= new Quaternion(0, 0, rotation * Time.deltaTime + angular * half_t_sq, 0);

        velocity += linear * Time.deltaTime;
        rotation += angular * Time.deltaTime;
    }
}
