using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    public string SceneName;

    public void OnSkipClick()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnSkipDemo()
    {
        PlayFabManager.instance.GetPlayerLevelData();
        StartCoroutine(LevelWaiter());
    }

    IEnumerator LevelWaiter()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneName);
    }
}
