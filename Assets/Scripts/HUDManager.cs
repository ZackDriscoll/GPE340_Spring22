using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text lifeCountText;
    public Text killCountText;
    public Image weaponImage;
    public GameObject gameOverUI;
    public GameObject pauseMenu;
    public bool isPaused = false;

    //Set the weapon image UI to be the current equiped weapon
    public void SetWeaponImage(Sprite weaponSprite)
    {
        weaponImage.sprite = weaponSprite;
        weaponImage.SetNativeSize();
    }

    //Set the lives count text to be the player's current life count
    public void SetLifeCountText()
    {
        lifeCountText.text = "Lives: " + GameManager.instance.lives.ToString();
    }

    //Set the kill count text to be the player's current life count
    public void SetKillCountText()
    {
        killCountText.text = "Enemies Killed: " + GameManager.instance.killCount.ToString();
    }

    //Pause the Game
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    //Resume the Game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
