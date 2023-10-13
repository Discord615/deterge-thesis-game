using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story){
        story.BindExternalFunction("startQuest", () => {
            DialogueManagaer.GetInstance().inkStart = true;
            DialogueManagaer.GetInstance().inkFinish = false;
        });

        story.BindExternalFunction("finishQuest", () => {
            DialogueManagaer.GetInstance().inkStart = false;
            DialogueManagaer.GetInstance().inkFinish = true;
        });
    }

    public void Unbind(Story story){
        story.UnbindExternalFunction("startQuest");
        story.UnbindExternalFunction("finishQuest");
    }
}