using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //When player reaches endzone, level complete
        if (other.tag == "Player")
            //Only allow player to trigger end
            gameManager.CompleteLevel();
    }
}
