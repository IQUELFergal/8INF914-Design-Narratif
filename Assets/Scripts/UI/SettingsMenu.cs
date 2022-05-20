using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SettingsMenu : Menu
{
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown fullScreenModeDropdown;
    [SerializeField] Resolution resolution;
    [SerializeField] FullScreenMode fullScreenMode;

    float generalVolume;
    float fxVolume;
    float musicVolume;
    float uiVolume;

    public static Action onOpenMenu;
    public static Action onCloseMenu;

    protected void OnEnable()
    {
        onOpenMenu += Open;
        onCloseMenu += Close;
    }

    protected void OnDisable()
    {
        onOpenMenu -= Open;
        onCloseMenu -= Close;
    }

    void Start()
    {
        PopulateFullScreenModeDropdown();
        PopulateResolutionDropdown();
    }

    public void CancelChanges()
    {
        LoadChanges();
        onCloseMenu?.Invoke();
    }

    public void ValidateChanges()
    {
        SaveChanges();
        ApplyChanges();
        onCloseMenu?.Invoke();
    }

    void RestoreDefaultParameters()
    {
        //Creer des parametres pardefaut en dur ou en playerpref
    }

    void LoadChanges()
    {
        resolution.width = PlayerPrefs.GetInt("ResolutionWidth");
        resolution.height = PlayerPrefs.GetInt("ResolutionHeight");
        resolution.refreshRate = PlayerPrefs.GetInt("ResolutionRefreshRate");
        fullScreenMode = (FullScreenMode)PlayerPrefs.GetInt("ResolutionFullScreenMode");

        generalVolume = PlayerPrefs.GetFloat("SoundGeneralVolume");
        fxVolume = PlayerPrefs.GetFloat("SoundFXVolume");
        musicVolume = PlayerPrefs.GetFloat("SoundMusicVolume");
        uiVolume = PlayerPrefs.GetFloat("SoundUIVolume");
    }

    void SaveChanges()
    {
        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
        PlayerPrefs.SetInt("ResolutionRefreshRate", resolution.refreshRate);
        PlayerPrefs.SetInt("ResolutionFullScreenMode", (int)fullScreenMode);

        PlayerPrefs.SetFloat("SoundGeneralVolume", generalVolume);
        PlayerPrefs.SetFloat("SoundFXVolume", fxVolume);
        PlayerPrefs.SetFloat("SoundMusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SoundUIVolume", uiVolume);
    }

    public void ApplyChanges()
    {
        Screen.SetResolution(resolution.width, resolution.height, fullScreenMode);
    }
    void PopulateResolutionDropdown()
    {
        List<string> options = new List<string>();
        for (int i = Screen.resolutions.Length - 1; i > 0; i--)
        {
            string resolution = Screen.resolutions[i].width + "x" + Screen.resolutions[i].height;
            options.Add(resolution);
        }

        if (resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(options);
        }
    }

    public void GetResolution(int index)
    {
        resolution = Screen.resolutions[index];
    }


    void PopulateFullScreenModeDropdown()
    {
        List<string> options = new List<string>();

        foreach (FullScreenMode foo in Enum.GetValues(typeof(FullScreenMode)))
        {
            options.Add(foo.ToString());
        }

        if (fullScreenModeDropdown != null)
        {
            fullScreenModeDropdown.ClearOptions();
            fullScreenModeDropdown.AddOptions(options);
        }
    }


    public void GetFullScreenMode(int index)
    {
        fullScreenMode = (FullScreenMode)index;
    }
}
