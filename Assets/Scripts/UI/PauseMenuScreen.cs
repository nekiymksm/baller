using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseMenuScreen : InGameMenuScreen
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _resumeButton;

    public event UnityAction RestartButtonClick;
    public event UnityAction MainMenuButtonClick;
    public event UnityAction ResumeButtonClick;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
    }

    private void OnMainMenuButtonClick()
    {
        MainMenuButtonClick?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    private void OnResumeButtonClick()
    {
        ResumeButtonClick?.Invoke();
    }
}
