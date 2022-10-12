using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{

    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textcolor;
        [SerializeField] private TMP_FontAsset textFont;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";

            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textcolor, textFont, delay, delayBetweenLines));
        }
    }

}

