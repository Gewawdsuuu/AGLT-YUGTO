using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        [SerializeField] private string SceneName;
        private string currentScene;

        private void Start()
        {
            Time.timeScale = 1.0f;
        }

        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }


        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(()=> transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }

            // Input code here on what to do after cutscene
            if (SceneManager.GetActiveScene().name == "CutsceneDemoStart")
            {
                PlayFabManager.instance.GetPlayerLevelData();
                StartCoroutine(LevelWaiter());
            }
            else
            {
                SceneManager.LoadScene(SceneName);
            }
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        IEnumerator LevelWaiter()
        {
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadScene(SceneName);
        }
    }

}

