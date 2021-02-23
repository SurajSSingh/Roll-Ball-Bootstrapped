using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldTimer : MonoBehaviour
{
    // Fields for the UI
    public Text timer;
    public GameObject loseGameText;
    public GameObject winnGameText;
    public GameObject retryButton;
    public GameObject continueButton;

    // Timer components
    private float mainTimer;
    public float timeLength;

    // Boolean flags used to determine branches in the code
    private  bool gameEnd;
    private bool gameOver;
    private bool run_timer = false;
    
    //Initialize timer and close menus
    void Start()
    {
        mainTimer = timeLength;
        timer.text = " Timer: " + mainTimer.ToString("0.00");

        CloseOpenMenu();
    }

    // While timer runs, check if the player has won or lost
    void Update()
    {
        if (run_timer)
        {
            if(gameEnd)
            {
                winnGameText.SetActive(true);
                continueButton.SetActive(true);
            } 
            else if (gameOver)
            {
                loseGameText.SetActive(true);
                retryButton.SetActive(true);
            }
        }
    }

    // Run the timer on a fixed timestep
    void FixedUpdate()
    {
        if (run_timer)
        {
            if(!gameOver && !gameEnd)
            {
                mainTimer -= Time.deltaTime;
                timer.text = " Timer: " + mainTimer.ToString("0.00");
                if (mainTimer <= 0.0f)
                {
                    gameOver = true;
                }
            }
        }
    }

    // If the game is not over and the player has won, then the game has ended
    public void GameEnd()
    {
        if (!gameOver)
        {
            gameEnd = true;
        }
    }

    // Reinitialized the timer and starts the timer
    public void StartTimer()
    {
        mainTimer = timeLength;
        run_timer = true;
    }

    // Stops the timer
    public void StopTimer()
    {
        run_timer = false;
    }

    // Closes all the open menus
    public void CloseOpenMenu()
    {
        gameEnd = false;
        gameOver = false;
        winnGameText.SetActive(false);
        loseGameText.SetActive(false);
        retryButton.SetActive(false);
        continueButton.SetActive(false);
    }
}
