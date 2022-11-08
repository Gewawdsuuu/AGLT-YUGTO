using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject quizPanel;
    public GameObject gameOverPanel;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;

    public Button nextButton;

    public Color fadeColor;

    int totalQuestions = 0;
    public int score;

    public static int levelsUnlocked;
    public static int currentLevel;

    private void Start()
    {
        levelsUnlocked = PlayFabManager.levelsUnlocked;
        currentLevel = LevelManager.currentLevel;

        totalQuestions = QnA.Count;
        GenerateQuestion();
        gameOverPanel.SetActive(false);

        Debug.Log(currentLevel);
    }

    private void Update()
    {
        if (score == totalQuestions)
        {
            nextButton.interactable = true;
        }
        else
        {
            nextButton.interactable = false;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.Instance.PlayMusic("Quiz Music");
    }

    public void GameOver()
    {
        quizPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreText.text = score + "/" + totalQuestions;

        if (score == totalQuestions)
        {
            if (levelsUnlocked <= (currentLevel + 1))
            {
                PlayFabManager.instance.GetLevelData();
            }
        }
    }

    public void NextButton()
    {
        AudioManager.Instance.PlayMusic("Main Menu");
        StartCoroutine(LoadLevel());
    }

    public void CorrectAnswer()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void WrongAnswer()
    {
        // When user answers incorrectly
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<Answers>().startColor;

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    private void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            questionText.text = QnA[currentQuestion].question;

            SetAnswers();
        }
        else
        {
            // No More Questions
            Debug.Log("Out of Questions");
            GameOver();
        }
    }

    public void OnExitSelect()
    {
        SceneManager.LoadScene("LevelSelection");
        AudioManager.Instance.PlayMusic("Main Menu");
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        GenerateQuestion();
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LevelSelection");
    }
}
