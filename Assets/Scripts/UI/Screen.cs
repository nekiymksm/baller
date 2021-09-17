using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public abstract class Screen : MonoBehaviour
{
    protected SceneLoader _sceneLoader;

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

    protected SceneLoader GetSceneLoader()
    {
        return _sceneLoader = GetComponent<SceneLoader>();
    }
}
