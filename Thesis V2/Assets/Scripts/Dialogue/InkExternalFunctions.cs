using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("startTutorial", () =>
        {
            Debug.Log("HOTDOGS");
            IntroSceneDialogueStart.instance.sceneIndex = 2;
        });

        story.BindExternalFunction("administerMeds", () =>
        {
            SyringeBehaviour.instance.resetValues();
            DialogueManager.instance.EndDialogue();
            MinigameManager.instance.playerHud.SetActive(false);
            MinigameManager.instance.syringeGame.SetActive(true);
            AssigningBottleWithMeds.instance.setBottleNames(GameWorldStatsManager.instance.activeVirusName);
        });

        story.BindExternalFunction("getSample", () =>
        {
            GameEventsManager.instance.miscEvents.sampleCollected();
        });

        story.BindExternalFunction("patientZeroFound", () => {
            GameEventsManager.instance.miscEvents.patientZeroFound();
        });


        // Tutorial Functions
        story.BindExternalFunction("startMovementTutorial", () =>
        {
            TutorialManager.instance.changeToDo("Use WASD or Arrow Keys to move");
        });

        story.BindExternalFunction("startRunningTutorial", () =>
        {
            TutorialManager.instance.changeToDo("Press and Hold the Left Shift while moving");
        });

        story.BindExternalFunction("startConvoWithDummy", () =>
        {
            TutorialManager.instance.finishMovementTest();
            TutorialManager.instance.startDummyTraining(false);
            TutorialManager.instance.changeToDo("Walk up to the dummy and interact with it");
        });

        story.BindExternalFunction("administerMedsTutorial", () =>
        {
            TutorialManager.instance.startDummyTraining(true);
            HealthBarReference.instance.healthPanel.SetActive(true);
            TutorialManager.instance.changeToDo("Interact with the dummy again to administer meds");
        });

        story.BindExternalFunction("sinkAndItems", () =>
        {
            TutorialManager.instance.endDummyTraining();
            TutorialManager.instance.toggleSinkAndItems();
            TutorialManager.instance.changeToDo("Collect items and Use Sink");
        });

        story.BindExternalFunction("kioskTutorial", () =>
        {
            TutorialManager.instance.toggleSinkAndItems();
            TutorialManager.instance.toggleKiosk();
            TutorialManager.instance.changeToDo("Interact with the kiosk");
        });

        story.BindExternalFunction("endTutorial", () =>
        {
            LoadingScreen.instance.LoadScene(3);
        });
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("startTutorial");
        story.UnbindExternalFunction("administerMeds");
        story.UnbindExternalFunction("getSample");
        story.UnbindExternalFunction("patientZeroFound");

        story.UnbindExternalFunction("startMovementTutorial");
        story.UnbindExternalFunction("startRunningTutorial");
        story.UnbindExternalFunction("startConvoWithDummy");
        story.UnbindExternalFunction("administerMedsTutorial");
        story.UnbindExternalFunction("sinkAndItems");
        story.UnbindExternalFunction("kioskTutorial");
        story.UnbindExternalFunction("endTutorial");
    }
}