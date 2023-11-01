using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class keyGenerator : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI keySequenceOutput;
    [SerializeField] private Timer timer;
    [SerializeField] private Slider slider;
    private List<string> combination;
    private string[] keys = {"W", "A", "S", "D"};
    private bool win = false;
    public bool reset = false;

    private void Start() {
        resetVariables();
    }

    private void Update() {
        if (InputManager.getInstance().getSpacePressedImpulse()) resetVariables();  // TODO: Remove in final build
        
        string letter = "";

        if (win) {
            timer.stopTimer = true;
            keySequenceOutput.text = "Treatment Successful";
            GameEventsManager.miscEvents.sequenceCompleted();
            return;
        }

        if (timer.timeOut){
            keySequenceOutput.text = "Treatment Unsuccessful";
            GameEventsManager.miscEvents.sequenceFailed();
            return;
        }
            
        if (combination.Count == 0) {
            win = true;
            return;
        }

        letter = combination[0];

        updateText(combination);

        if (letter == "W" && InputManager.getInstance().GetMovePressImpulse() == Vector2.up) updateArray();
        else if (letter == "A" && InputManager.getInstance().GetMovePressImpulse() == Vector2.left) updateArray();
        else if (letter == "S" && InputManager.getInstance().GetMovePressImpulse() == Vector2.down) updateArray();
        else if (letter == "D" && InputManager.getInstance().GetMovePressImpulse() == Vector2.right) updateArray();
    }

    private void updateArray(){
        try{
            combination.RemoveAt(0);
            timer.correctLetter();
        } catch (System.Exception){
            win = true;
        }
    }

    private List<string> generateRandomKeys(){
        float numberOfKeys = Random.Range(4, 8);
        List<string> resultArr = new List<string>();
        
        for (int i = 0; i < numberOfKeys; i++){
            resultArr.Add(keys[Random.Range(0, keys.Length)]);
        }
        return resultArr;
    }

    private void updateText(List<string> characterCollection){
        string result = "";

        foreach (string item in characterCollection){
            result += item + " ";
        }

        keySequenceOutput.text = result;
    }

    private void resetVariables(){
        combination = generateRandomKeys();
        slider.value = slider.minValue;
        win = false;
        timer.timeOut = false;
        timer.stopTimer = false;
    }
}
