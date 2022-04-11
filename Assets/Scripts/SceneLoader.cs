using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

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

    public void StartGameplay()
    {
        //Transition to the gameplay scene
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMainMenu()
    {
        //Transition to the Main Menu scene
        SceneManager.LoadScene("Main Menu");
    }
}
