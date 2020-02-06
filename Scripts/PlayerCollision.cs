using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Reference to player movement script
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Obstacle")
        {
            //Disable player movement and end the game when obstacle is hit
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
