using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class represents the game! SO: Everything that is in our game should be accessable from here.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        //If I am the first
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //There is already a GameManager, so destroy myself
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Show Main Menu
    }

    //StartGame starts when gameplay starts
    public void StartGame()
    {
        //Set score to zero
        //Spawn the player
        //Turn on the enemy spawners
    }

    //EndGame runs when the player is out of lives
    public void EndGame()
    {
        //Send a command to stop the controller from controlling the player
        //Show GameOver Overlay
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
