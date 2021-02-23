using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Stops the game before the level starts
    void Awake()
    {
        Time.timeScale = 0f;
    }

    // Starts the level timer and hides start overlay
    public void OnStartClick()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
