using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSFXSliderValue : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider slider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float value;
        bool result = audioMixer.GetFloat("sfxVolume", out value);
        slider.value = value;
    }
}
