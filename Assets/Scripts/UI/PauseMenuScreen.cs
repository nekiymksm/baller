using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScreen : Screen
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _resumeButton;

    private void Start()
    {
        GetSceneLoader();
    }

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _resumeButton.onClick.AddListener(CloseScreen);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _resumeButton.onClick.RemoveListener(CloseScreen);
    }

    private void OnMainMenuButtonClick()
    {
        _sceneLoader.LoadScene(SceneLoader._mainMenuSceneName);
    }

    private void OnRestartButtonClick()
    {
        _sceneLoader.LoadScene(SceneLoader._startingLevelSceneName);

        CloseScreen();
    }
}
