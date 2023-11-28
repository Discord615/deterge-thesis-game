using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SyringeBehaviour : MonoBehaviour
{
    public static SyringeBehaviour instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Syringe Behavior Exists in current scene");
        }
        instance = this;
    }

    [Header("Objects")]
    [SerializeField] private Slider syringe;
    [SerializeField] private TextMeshProUGUI textValue;

    [Header("Variables")]
    [SerializeField] private float syringeValue;
    [SerializeField] private float maxSyringeValue = 100f;
    [SerializeField] private float acceleration = 60f;
    [SerializeField] private float currentSyringeSpeed = 0f;
    [SerializeField] private float maxSyringeSpeed = 100f;

    public string medBottleLabel;

    private bool stop = false;
    private bool finished = false;

    private void Update()
    {
        if (medBottleLabel == null) return;
        SyringeValueChanger();
    }

    public void resetValues()
    {
        currentSyringeSpeed = 0f;
        stop = false;
        finished = false;
        syringeValue = 0f;
    }

    void SyringeValueChanger()
    {
        bool press = InputManager.getInstance().getSpacePressedHold();
        if (currentSyringeSpeed >= maxSyringeSpeed - 0.05f) currentSyringeSpeed = maxSyringeSpeed;

        if (syringeValue >= maxSyringeValue - 0.05f) syringeValue = maxSyringeValue;

        string suffix = "";

        if (AssigningBottleWithMeds.instance.dosageValue >= 1000) suffix = "00 mg";
        if (AssigningBottleWithMeds.instance.dosageValue >= 100 && AssigningBottleWithMeds.instance.dosageValue < 999) suffix = "0 mg";
        else suffix = " mg";

        textValue.text = Mathf.CeilToInt(syringeValue).ToString() + suffix;
        syringe.value = syringeValue;

        if (!press && stop)
        {
            finished = true;
            checkCorrection();
        }

        if (press && !finished && medBottleLabel != null)
        {
            if (!stop) stop = true;
            currentSyringeSpeed += acceleration * Time.deltaTime * 0.5f;
            syringeValue += currentSyringeSpeed * Time.deltaTime;
            currentSyringeSpeed += acceleration * Time.deltaTime * 0.5f;
        }
    }

    private void checkCorrection()
    {
        float rawDosageValue = AssigningBottleWithMeds.instance.dosageValue;
        float dosageValue;
        if (rawDosageValue >= 1000) dosageValue = Mathf.Ceil(rawDosageValue * 0.01f);
        if (rawDosageValue >= 100 && rawDosageValue < 999) dosageValue = Mathf.Ceil(rawDosageValue * 0.1f);
        else dosageValue = rawDosageValue;

        float marginOfError = 10f;

        if (!((Mathf.Abs(syringeValue - dosageValue) < marginOfError) && (Mathf.Abs(syringeValue + dosageValue) > marginOfError)))
        {
            Lose();
            return;
        }

        if (!isMedCorrect())
        {
            Lose();
            return;
        }

        PlayerHealthManager.instance.reduceHealth();
        GameEventsManager.instance.miscEvents.patientSaved();
    }

    private bool isMedCorrect()
    {
        foreach (string medName in AssigningBottleWithMeds.instance.mainVirusMeds)
        {
            if (medName.Equals(medBottleLabel)) return true;
        }
        return false;
    }

    private void Lose()
    {
        MinigameManager.instance.syringeGame.SetActive(false);

        MinigameManager.instance.onBeatGame.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        medBottleLabel = other.GetComponent<BottleBehavior>().medLabel;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        medBottleLabel = null;
    }
}
