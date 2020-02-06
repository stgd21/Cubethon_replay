using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Reference player position and camera offset value
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //Fix camera behind player with offset set in inspector
        transform.position = player.position + offset;
    }
}
