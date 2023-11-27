using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSFXManager : MonoBehaviour
{
    public static TutorialSFXManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There are more than one instance of Tutorial SFX Manager in the current scene");
        }
        instance = this;
    }

    [SerializeField] private AudioSource ButtonSFXSource;

    public void SFXOnButtonClick()
    {
        ButtonSFXSource.Play();
    }
}
