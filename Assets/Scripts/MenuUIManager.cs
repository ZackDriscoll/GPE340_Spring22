using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    //References to the Main Menu and Options Menu parent objects
    public GameObject mainMenu;
    public GameObject optionsMenu;

    //Reference to the audio mixer
    public AudioMixer audioMixer;

    //Reference to the resolution dropdown UI object
    public Dropdown resolutionDropdown;

    //Array of all the available resolutions
    Resolution[] resolutions;

    private void Start()
    {
        //Set the options menu UI to inactive on start
        optionsMenu.SetActive(false);

        //Get all of the available screen resolutions
        resolutions = Screen.resolutions;

        //Clear out the resolution dropdown
        resolutionDropdown.ClearOptions();

        //Create a list to hold all of the resolutions as strings
        List<string> options = new List<string>();

        int currentRsolutionIndex = 0;

        //Iterate through all of the resolutions and add them to the string list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentRsolutionIndex = i;
            }
        }

        //Add the list options to the resolution dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRsolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Set the Master Volume Slider
    public void SetMasterVolume(float masterVolume)
    {
        audioMixer.SetFloat("MasterVolume", masterVolume);
    }

    //Set the Music Volume Slider
    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("MusicVolume", musicVolume);
    }

    //Set the SFX Volume Slider
    public void SetSFXVolume(float sfxVolume)
    {
        audioMixer.SetFloat("SFXVolume", sfxVolume);
    }

    //Set the Resolution settings
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Set the Quality settings
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Activate Options Menu
    public void ActivateOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    //Activate Main Menu
    public void ActivateMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
