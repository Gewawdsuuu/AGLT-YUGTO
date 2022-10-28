using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public Color startColor;
    public Color correctColor;
    public Color wrongColor;

    private void Start()
    {

    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = correctColor;
            Debug.Log("Correct Answer");
            quizManager.CorrectAnswer();
        }
        else
        {
            GetComponent<Image>().color = wrongColor;
            Debug.Log("Wrong Answer");
            quizManager.WrongAnswer();
        }
    }
}
