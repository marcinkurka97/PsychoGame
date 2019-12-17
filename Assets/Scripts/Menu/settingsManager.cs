using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class settingsManager : MonoBehaviour
{

     

    public Slider volumeSlider;
    public Toggle enableMusic;
    public Toggle enableEffects;

    


    
    private const string VOLUME_PREF = "volume";

    private const string MUSIC_PREF = "music";

    private const string EFFECTS_PREF = "effects";





    


   
    void Start()
    {

        volumeSlider.value = PlayerPrefs.GetFloat(VOLUME_PREF, 1);

        enableEffects.isOn = GetBoolPref(EFFECTS_PREF);
        enableMusic.isOn = GetBoolPref(MUSIC_PREF);
    }


    void Update()
    {

    }

    
    public void OnChangeSoundVolume(Single value)
    {
        SetPref(VOLUME_PREF, value);
    }



    

    public void OnToggleMusic(bool state)
    {

        SetPref(MUSIC_PREF, state);

    }
    public void OnToggleEffects(bool state)
    {

        SetPref(EFFECTS_PREF, state);

    }


    

    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    private void SetPref(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    private void SetPref(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    private void SetPref(string key, bool value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    private bool GetBoolPref(string key, bool defaultValue = true)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(key, Convert.ToInt32(defaultValue)));
    }

}