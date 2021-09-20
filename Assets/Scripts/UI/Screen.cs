using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    protected string _startingLevelSceneName = "Level0";
    protected string _mainMenuSceneName = "MainMenu";

    public virtual void OpenScreen()
    {
        Time.timeScale = 0;

        gameObject.SetActive(true);
    }

    public virtual void CloseScreen()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);
    }
}
