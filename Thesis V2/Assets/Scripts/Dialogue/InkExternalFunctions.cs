using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("administerMeds", () =>
        {
            SyringeBehaviour.instance.resetValues();
            DialogueManager.instance.EndDialogue();
            MinigameManager.instance.playerHud.SetActive(false);
            MinigameManager.instance.syringeGame.SetActive(true);
            AssigningBottleWithMeds.instance.setBottleNames(GameWorldStatsManager.instance.activeVirusName);
        });

        story.BindExternalFunction("spreadSickness", (string virusName) => {
            GameWorldStatsManager.instance.activeVirusName = virusName;
            SicknessManager.instance.spreadSickness();
        });

        story.BindExternalFunction("getSample", () => {
            GameEventsManager.instance.miscEvents.sampleCollected();
        });
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("administerMeds");
        story.UnbindExternalFunction("spreadSickness");
        story.UnbindExternalFunction("getSample");
    }
}