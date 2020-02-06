using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //When player hits powerup, make enemies flee for 1 second
            SeekAndFlee.isSeeking = false;
            GetComponent<MeshRenderer>().enabled = false;
            Invoke("PowerUpEnd", 1f);
        }
    }

    private void PowerUpEnd()
    {
        //Return enemies to normal seek behavior after 1 second
        SeekAndFlee.isSeeking = true;
        Destroy(this.gameObject);
    }
}
