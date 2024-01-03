using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace desiredWord
{
    public class wordCheck : MonoBehaviour
    {
        [SerializeField] private DesiredWord word;
        [SerializeField] private Image img;
        [SerializeField] private TMP_InputField input;

        private void Awake()
        {
            input.characterLimit = 1;
        }

        private void OnEnable() {
            GameEventsManager.instance.miscEvents.completeCrossWord += TextCheckHandler;
        }

        private void TextCheckHandler()
        {
            if (input.text == word.UpperCase || input.text == word.LowerCase)
            {
                img.color = Color.green;
                input.interactable = false;
                GameEventsManager.instance.miscEvents.onLetterFound();
                return;
            }

            if (input.text == "")
            {
                img.color = Color.white;
                return;
            }

            img.color = Color.red;
        }
    }
}