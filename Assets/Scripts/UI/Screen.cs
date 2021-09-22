using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    protected string _startingLevelSceneName = "Level0";
    protected string _mainMenuSceneName = "MainMenu";

    public virtual void Open()
    {
        Time.timeScale = 0;

        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);
    }
}
