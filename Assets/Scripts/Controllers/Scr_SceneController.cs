using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scr_SceneController : MonoBehaviour
{
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
