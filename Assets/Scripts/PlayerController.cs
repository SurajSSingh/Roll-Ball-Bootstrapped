using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Contains the base information about the player
    private Rigidbody rb;
    private uint points;
    private bool levelComplete;
    private int level;

    // UI field used by the player
    public Text scoreBoard;

    // Arrays used to hold information about 
    // game level and their pickup holder
    public GameObject[] levels;
    public GameObject[] holders;
    private int maxLevel = 2;

    // Initialize the player informations
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        level = 0;
        Retry();
    }

    // Tracks if player has won yet
    // Also checks if player want to quit
    void Update()
    {
        if(points == 16)
        {
            levels[level % maxLevel].GetComponent<WorldTimer>().GameEnd();
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Processes the movement of the player
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(horizontal,0.0f,vertical);
        rb.AddForce(force);
    }

    // Used to 'pick up' the pickup object
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            points++;
            scoreBoard.text = "Score: " + points.ToString() + " ";
        }
    }

    // Moves the player to the next level in the array
    public void nextLevel()
    {
        levels[level % maxLevel].GetComponent<WorldTimer>().StopTimer();
        holders[level % maxLevel].GetComponent<PickupHolder>().Deactivate();
        level++;
        Retry();
    }

    // Clears the player's points and returns the player to the start position
    public void Retry()
    {
        points = 0;
        scoreBoard.text = "Score: " + points.ToString() + " ";
        rb.transform.position = new Vector3(levels[level % maxLevel].transform.position.x,1.0f,0.0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        holders[level % maxLevel].GetComponent<PickupHolder>().Activate();
        levels[level % maxLevel].GetComponent<WorldTimer>().CloseOpenMenu();
        levels[level % maxLevel].GetComponent<WorldTimer>().StartTimer();
    }
}
