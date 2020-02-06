using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //Load scenes sequentially via build indices
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
