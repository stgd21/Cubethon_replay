using UnityEngine;

public class SeekAndFlee : MonoBehaviour
{
    //Toggle between seeking and fleeing behaviors for all enemies
    public static bool isSeeking = true;
    //Only one possible max speed for now
    public static float maxSpeed = 30.0f;
    //Acceptable Arrive Radius
    public static float arriveRadius = 2.0f;
    //Reference the player as the target
    public Transform playerTarget;
    //Vector to seek/flee in determined every frame
    private Vector3 directionToMove;

    private void Start()
    {
        //Get the reference to the player's Transform component
        if (playerTarget == null)
            playerTarget = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        //Seek behavior
        if (isSeeking == true)
            //Seek player
            directionToMove = playerTarget.position - transform.position;
        else
            //Flee player
            directionToMove = transform.position - playerTarget.position;

        //Arrive Behavior
        if (directionToMove.magnitude < arriveRadius)
            //Do not move if within arrival radius
            return;
        else
        {
            //Movement Behavior
            directionToMove.Normalize();
            directionToMove *= maxSpeed;
            //Apply force to this gameobject to move it in appropriate vector
            GetComponent<Rigidbody>().AddForce(directionToMove.x * Time.deltaTime,
                directionToMove.y * Time.deltaTime,
                directionToMove.z * Time.deltaTime, ForceMode.VelocityChange);
            //Look in direction of movement at all times
            transform.LookAt(directionToMove);
        }
    }
}
