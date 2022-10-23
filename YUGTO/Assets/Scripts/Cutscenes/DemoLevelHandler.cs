using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoLevelHandler : MonoBehaviour
{
    public static int levelsUnlocked;
    public static int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        levelsUnlocked = PlayFabManager.levelsUnlocked;

        Debug.Log(currentLevel);

        if (levelsUnlocked <= (currentLevel + 1))
        {
            PlayFabManager.instance.GetLevelData();
        }
    }
}
