using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the game! SO: Everything that is in our game should be accessable from here.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives;
    public int killCount = 0;
    public int killsToWin = 3;
    public HUDManager hudManager;

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

    private void Start()
    {
        //Make sure the game over UI is deactivated on start
        hudManager.gameOverUI.SetActive(false);

        //Make sure the timescale is set to 1
        Time.timeScale = 1;

        //Reset the player's lives value
        lives = 2;

        //Set the player's lives text
        hudManager.SetLifeCountText();

        //Set the player's kill count text
        hudManager.SetKillCountText();
    }

    private void Update()
    {
        //Once the player has killed enough enemies...
        if (killCount >= killsToWin)
        {
            //Activate the game over UI
            hudManager.gameOverUI.SetActive(true);

            //Pause the game in the background by setting the timescale to 0
            Time.timeScale = 0;
        }
    }

    //When the player clicks the quit button on the main menu
    public void QuitGame()
    {
        Application.Quit();
    }
}
