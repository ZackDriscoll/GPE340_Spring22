using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderToMixerTest : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public AudioMixer audioMixer;
    public string parameterToMatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMixerValue()
    {
        audioMixer.SetFloat(parameterToMatch, Mathf.Lerp(-80.0f, 20.0f, masterVolumeSlider.value));
    }
}
