using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameOverScreen : InGameMenuScreen
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _tryAgainButton;

    public event UnityAction TryAgainButtonClick;
    public event UnityAction MainMenuButtonClick;

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
        MainMenuButtonClick?.Invoke();
    }

    private void OnTryAgainButtonClick()
    {
        TryAgainButtonClick?.Invoke();
    }
}
