using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1.0f;
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        //Activate level complete UI
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            //Only allow one gameover and restart the game
            Debug.Log("Gameover");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }   
    }

    void Restart()
    {
        //Reload active scene when gameover occurs
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
