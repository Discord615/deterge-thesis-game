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
            input.onValueChanged.AddListener(TextCheckHandler);
        }

        private void TextCheckHandler(string arg0)
        {
            if (arg0 == word.UpperCase || arg0 == word.LowerCase)
            {
                img.color = Color.green;
                return;
            }

            if (arg0 == "")
            {
                img.color = Color.white;
                return;
            }

            img.color = Color.red;
        }
    }
}