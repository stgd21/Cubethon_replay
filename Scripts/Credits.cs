using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void Quit()
    {
        //Referenced via Quit button
        Debug.Log("Quit");
        Application.Quit();
    }
}
