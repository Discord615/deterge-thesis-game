using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider BGM;
    [SerializeField] private Slider SFX;
    [SerializeField] private Slider Master;

    [SerializeField] private AudioSource volumeTester;

    public const string mixerBGM = "BGM";
    public const string mixerSFX = "SFX";
    public const string mixerMaster = "Master";

    private void Awake() {
        BGM.onValueChanged.AddListener(setBGMVolume);
        SFX.onValueChanged.AddListener(setSFXVolume);
        Master.onValueChanged.AddListener(setMasterVolume);
    }

    private void Start() {
        BGM.value = PlayerPrefs.GetFloat(AudioManager.bgmKey, 0f);
        SFX.value = PlayerPrefs.GetFloat(AudioManager.sfxKey, 0f);
        Master.value = PlayerPrefs.GetFloat(AudioManager.masterKey, 0f);
    }

    private void OnDisable() {
        PlayerPrefs.SetFloat(AudioManager.bgmKey, BGM.value);
        PlayerPrefs.SetFloat(AudioManager.sfxKey, SFX.value);
        PlayerPrefs.SetFloat(AudioManager.masterKey, Master.value);
    }

    private void setBGMVolume(float value){
        mixer.SetFloat(mixerBGM, value);
    }

    private void setSFXVolume(float value){
        mixer.SetFloat(mixerSFX, value);
        volumeTester.Stop();
        volumeTester.Play();
    }

    private void setMasterVolume(float value){
        mixer.SetFloat(mixerMaster, value);
    }
}