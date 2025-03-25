using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public void LoadSampleScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void BackMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Camera");
    }
}
