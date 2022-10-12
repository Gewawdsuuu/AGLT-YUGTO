using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{

    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, TMP_FontAsset textFont, float delay, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];

                yield return new WaitForSeconds(delay);

            }

            /* -- Uncomment This line if you want time based skip between lines -- */
            //yield return new WaitForSeconds(delayBetweenLines);

            /* -- This line waits for user input before going to the next line -- */
            yield return new WaitUntil(()=> Input.GetMouseButtonDown(0));

            finished = true;
        }
    }

}
