using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _tryAgainButton;

    private void Start()
    {
        GetSceneLoader();
    }

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _tryAgainButton.onClick.AddListener(OnTryAgainButtonClick);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
        _tryAgainButton.onClick.RemoveListener(OnTryAgainButtonClick);
    }

    private void OnMainMenuButtonClick()
    {
        _sceneLoader.LoadScene(SceneLoader._mainMenuSceneName);
    }

    private void OnTryAgainButtonClick()
    {
        _sceneLoader.LoadScene(SceneLoader._startingLevelSceneName);

        CloseScreen();
    }
}
