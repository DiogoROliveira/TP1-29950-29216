using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI volumeValue;
    public AudioMixer audioMixer;
    public TMP_Dropdown resDropdown;
    public Slider volumeSlider;
    public GameObject settingsMenu;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }

        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

        volumeSlider.value = 1f;
        volumeValue.text = "100";
        audioMixer.SetFloat("Volume", 0f);

    }

    public void SetVolume(float volume)
    {

        float dB = 20 * (float)Math.Log10(volume);
        string vol;
        vol = (volume * 100).ToString("0");

        if (volume == 0)
        {
            audioMixer.SetFloat("Volume", -80f);
            volumeValue.text = "0";
            return;
        }

        audioMixer.SetFloat("Volume", dB);
        volumeValue.text = vol;
    }

    public void ChangeRes(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
    }

}
