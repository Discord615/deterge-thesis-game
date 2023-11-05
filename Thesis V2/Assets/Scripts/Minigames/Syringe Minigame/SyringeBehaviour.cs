using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SyringeBehaviour : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Slider syringe;
    [SerializeField] private TextMeshProUGUI textValue;

    [Header("Variables")]
    [SerializeField] private float syringeValue;
    [SerializeField] private float maxSyringeValue = 100f;
    [SerializeField] private float acceleration = 60f;
    [SerializeField] private float currentSyringeSpeed = 0f;
    [SerializeField] private float maxSyringeSpeed = 100f;

    private bool stop = false;
    private bool finished = false;

    private void Update()
    {
        SyringeValueChanger();
    }

    void SyringeValueChanger()
    {
        bool press = InputManager.getInstance().getSpacePressedHold();
        if (currentSyringeSpeed >= maxSyringeSpeed - 0.05f) currentSyringeSpeed = maxSyringeSpeed;

        if (syringeValue >= maxSyringeValue - 0.05f) syringeValue = maxSyringeValue;

        textValue.text = Mathf.CeilToInt(syringeValue).ToString() + " mg";
        syringe.value = syringeValue;

        if (!press && stop) finished = true;    // TODO: Add win or lose event
                                                // TODO: From BottleBehavior.cs add a check if medicine passed is correct which triggers a win event.
                                                // TODO: if medicine is incorrect then trigger lose event.

        if (press && !finished)
        {
            if (!stop) stop = true;
            currentSyringeSpeed += acceleration * Time.deltaTime * 0.5f;
            syringeValue += currentSyringeSpeed * Time.deltaTime;
            currentSyringeSpeed += acceleration * Time.deltaTime * 0.5f;
        }
    }
}
