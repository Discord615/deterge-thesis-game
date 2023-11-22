using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of Settings Manager in current scene");
        }
        instance = this;
    }

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropDown;
    public TextMeshProUGUI qualityOutput;

    private void Start() {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = string.Format("{0} x {1}", resolutions[i].width, resolutions[i].height);
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.height && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void setQuality(int qualityIndex){
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

    public void setFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }
}
