using UnityEngine;

[System.Serializable]
public class QuestionsAndAnswers
{
    [TextArea(3,8)]public string question;
    public string[] answers;
    public int correctAnswer;
}
