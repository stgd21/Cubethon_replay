using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Reference player position and text to update
    public Transform player;
    public Text scoreText;

    //Update called once per frame
    void Update()
    {
        //Update text with player position whole number
        scoreText.text = player.position.z.ToString("0");
    }
}
