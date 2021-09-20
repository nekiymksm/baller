using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _tryAgainButton;

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
        SceneManager.LoadScene(_mainMenuSceneName);
    }

    private void OnTryAgainButtonClick()
    {
        SceneManager.LoadScene(_startingLevelSceneName);

        CloseScreen();
    }
}
