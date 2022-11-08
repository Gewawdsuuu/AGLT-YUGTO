using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPlayMusic : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Quiz Music");
    }
}
