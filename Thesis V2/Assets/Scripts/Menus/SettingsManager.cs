using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There are more than one instance of Settings Manager in current scene");
        }
        instance = this;
    }

    Resolution[] resolutions;
    List<Resolution> filteredResolutions;
    float currentRefreshRate;

    public TMP_Dropdown resolutionDropDown;
    public TextMeshProUGUI qualityOutput;

    private void Start()
    {
        #region Resolution Initialization
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        currentRefreshRate = Screen.currentResolution.refreshRate;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate != currentRefreshRate) continue;

            if ((resolutions[i].width / (double)resolutions[i].height) != (1920D / 1080D)) continue;

            filteredResolutions.Add(resolutions[i]);
        }

        foreach (var item in filteredResolutions)
        {
            Debug.Log(item.width + " " + item.height);
        }

        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string option = string.Format("{0} x {1}", filteredResolutions[i].width, filteredResolutions[i].height, filteredResolutions[i].refreshRate);
            options.Add(option);

            if (filteredResolutions[i].width == Screen.currentResolution.width && filteredResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        #endregion
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        switch (qualityIndex)
        {
            case 0:
                qualityOutput.text = "Quality: Low";
                break;

            case 1:
                qualityOutput.text = "Quality: Medium";
                break;

            case 2:
                qualityOutput.text = "Quality: High";
                break;
        }


    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }
}
