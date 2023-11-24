using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class keyGenerator : MonoBehaviour{
    public static keyGenerator instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Key Generator in current scene");
        }
        instance = this;
    }

    [SerializeField] private TextMeshProUGUI keySequenceOutput;
    [SerializeField] private TextMeshProUGUI winsLeftOutput;
    [SerializeField] private Timer timer;
    [SerializeField] private Slider slider;
    private List<string> combination;
    private string[] keys = {"W", "A", "S", "D"};
    private bool win = false;
    public bool reset = false;

    [SerializeField] private int maxNumberOfKeys;

    // * Win Counter
    int winsLeft = 3;

    private void Start() {
        resetVariables();
    }

    private void Update() {

        if (winsLeft > 1 && win){
            winsLeft--;
            win = false;
            resetVariables();
            return;
        }

        winsLeftOutput.text = string.Format("Successful Sequences Needed: {0}", winsLeft);

        if (win) {
            timer.stopTimer = true;
            timer.startTimer = false;
            keySequenceOutput.text = "Treatment Successful";
            GameEventsManager.instance.miscEvents.sequenceCompleted();
            return;
        }

        if (timer.timeOut){
            timer.startTimer = false;
            keySequenceOutput.text = "Treatment Unsuccessful";
            GameEventsManager.instance.miscEvents.sequenceFailed();
            return;
        }

        if (combination.Count == 0) {
            win = true;
            return;
        }

        string letter = combination[0];
        updateText(combination);

        if (letter == "W" && InputManager.getInstance().GetMovePressImpulse() == Vector2.up) updateArray();
        else if (letter == "A" && InputManager.getInstance().GetMovePressImpulse() == Vector2.left) updateArray();
        else if (letter == "S" && InputManager.getInstance().GetMovePressImpulse() == Vector2.down) updateArray();
        else if (letter == "D" && InputManager.getInstance().GetMovePressImpulse() == Vector2.right) updateArray();
    }

    private void updateArray(){
        timer.startTimer = true;

        try{
            combination.RemoveAt(0);
            timer.correctLetter();
        } catch (System.Exception){
            win = true;
        }
    }

    private List<string> generateRandomKeys(){
        float numberOfKeys = Random.Range(4, maxNumberOfKeys);
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

    public void resetVariables(){
        timer.timeOut = false;
        timer.stopTimer = false;
        win = false;
        combination = generateRandomKeys();
        slider.value = slider.maxValue;
    }
}
