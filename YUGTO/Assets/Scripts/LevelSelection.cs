using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{ 
    public void OnLevelSelect(Button button)
    {
        SceneManager.LoadScene("Level "  + button.name);
    }

}
