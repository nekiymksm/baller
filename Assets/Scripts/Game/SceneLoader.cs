using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const string _startingLevelSceneName = "Level0";
    public const string _mainMenuSceneName = "MainMenu";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
