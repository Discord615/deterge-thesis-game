using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [SerializeField] private AudioMixer mixer;

    public const string masterKey = "Master";
    public const string bgmKey = "BGM";
    public const string sfxKey = "SFX";

    private void Awake() {
        if (instance == null){
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        LoadVolume();
    }

    private void LoadVolume(){
        float bgmVol = PlayerPrefs.GetFloat(bgmKey, 0f);
        float sfxVol = PlayerPrefs.GetFloat(sfxKey, 0f);
        float masterVol = PlayerPrefs.GetFloat(masterKey, 0f);

        mixer.SetFloat(VolumeSettings.mixerBGM, bgmVol);
        mixer.SetFloat(VolumeSettings.mixerSFX, sfxVol);
        mixer.SetFloat(VolumeSettings.mixerMaster, masterVol);
    }
}
