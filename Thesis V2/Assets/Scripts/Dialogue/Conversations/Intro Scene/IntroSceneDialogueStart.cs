using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class IntroSceneDialogueStart : MonoBehaviour
{
    [SerializeField] private TextAsset dialogue;
    [SerializeField] private AudioClip phoneVibes;
    [SerializeField] private AudioClip callPickUp;
    [SerializeField] private AudioClip callEnd;
    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private GameObject blinder;

    public static IntroSceneDialogueStart instance { get; private set; }

    private void Awake() {
        if (instance != null) {
            Debug.LogError("More than one instance of Intro Scene Dialogue Start exists in the current scene");
        }
        instance = this;
    }

    bool isEndCall = false;
    bool hasSetEndCall = false;
    bool Faded = false;
    bool dialogueStarted = false;
    CanvasGroup blindGroup;

    public int sceneIndex = 3;


    private void Start() {
        blindGroup = blinder.GetComponent<CanvasGroup>();
        StartCoroutine(playSound());
    }

    private void Update() {
        if (blindGroup.alpha <= 0 && !DialogueManager.instance.dialogueIsPlaying && !dialogueStarted) {
            DialogueManager.instance.EnterDialogueMode(dialogue);
            dialogueStarted = true;
        }

        if (DialogueManager.instance.dialogueIsPlaying || blindGroup.alpha > 0) return;

        Debug.Log("TEST");

        if (isEndCall){
            isEndCall = false;
            StartCoroutine(playSound(callEnd));
        } else if (!hasSetEndCall) {
            isEndCall = true;
            hasSetEndCall = true;
        }
    }

    IEnumerator playSound(AudioClip clip){
        SFX.clip = clip;

        SFX.Play();

        while (SFX.isPlaying)
        {
            yield return null;
        }

        fadeBlinder();
    }

    IEnumerator playSound(){
        SFX.clip = phoneVibes;

        SFX.Play();

        while (SFX.isPlaying)
        {
            yield return null;
        }

        SFX.clip = callPickUp;

        SFX.Play();

        while (SFX.isPlaying)
        {
            yield return null;
        }

        fadeBlinder();
    }

    private void fadeBlinder(){
        StartCoroutine(fade(blindGroup, blindGroup.alpha, Faded ? 1 : 0));

        Faded = !Faded;
    }

    IEnumerator fade(CanvasGroup group, float start, float end){
        float counter = 0f;

        while (counter < 0.4f){
            counter += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, end, counter/0.4f);

            yield return null;
        }

        if (Faded) BGM.Play();
        else LoadingScreen.instance.LoadScene(sceneIndex); // TODO: Should be changed based on the dialogue option
    }
}
