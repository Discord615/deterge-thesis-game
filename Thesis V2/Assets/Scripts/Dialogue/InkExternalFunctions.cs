using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("administerMeds", (string mainVirus) =>
        {
            SyringeBehaviour.instance.resetValues();
            MinigameManager.instance.playerHud.SetActive(false);
            MinigameManager.instance.syringeGame.SetActive(true);
            AssigningBottleWithMeds.instance.setBottleNames(mainVirus);
        });

        story.BindExternalFunction("spreadSickness", () => {
            SicknessManager.instance.displayNumberOfSickStudents = true;
            GameWorldStatsManager.instance.activeVirusName = "tuber";
            SicknessManager.instance.spreadSickness();
        });
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("administerMeds");
        story.UnbindExternalFunction("spreadSickness");
    }
}