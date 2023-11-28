using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Tutorial Manager exists in current scene");
        }
        instance = this;
    }

    [Header("Tutorial General Variables")]
    public TextAsset[] tutorialDialogue;
    public int tutorialIndex = 0;

    [Header("Tutorial Objects")]
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI tutorialTodo;
    [SerializeField] private Slider progress;
    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject sinkAndItems;
    [SerializeField] private GameObject kiosk;

    private void Update()
    {
        if (DialogueManager.instance.dialogueIsPlaying || MinigameManager.instance.syringeGame.activeInHierarchy)
            tutorialPanel.SetActive(false);
        else tutorialPanel.SetActive(true);
    }

    private void Start()
    {
        dummy.SetActive(false);
        sinkAndItems.SetActive(false);
        kiosk.SetActive(false);
        continueTutorial();
    }

    public void continueTutorial()
    {
        DialogueManager.instance.EnterDialogueMode(tutorialDialogue[tutorialIndex]);
        tutorialIndex++;
    }

    public void changeToDo(string text)
    {
        tutorialTodo.text = text;
    }

    public void finishMovementTest()
    {
        if (progress.gameObject.activeInHierarchy) progress.gameObject.SetActive(false);
    }

    public void startDummyTraining(bool isAdminister)
    {
        if (!dummy.activeInHierarchy) dummy.SetActive(true);

        dummy.GetComponent<InteractDummy>().enabled = !isAdminister;
        dummy.GetComponent<AdministeringPractice>().enabled = isAdminister;
    }

    public void endDummyTraining()
    {
        dummy.SetActive(false);
    }

    public void toggleSinkAndItems()
    {
        sinkAndItems.SetActive(!sinkAndItems.activeInHierarchy);
    }

    public void toggleKiosk()
    {
        kiosk.SetActive(!kiosk.activeInHierarchy);
    }
}
