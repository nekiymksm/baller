using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseMenu : GameOverScreen
{
    [SerializeField] private Button _resume;

    public event UnityAction ResumeButtonClick;

    private void OnEnable()
    {
        MainMenu.onClick.AddListener(OnMainMenuButtonClick);
        Restart.onClick.AddListener(OnRestartButtonClick);
        _resume.onClick.AddListener(OnResumeButtonClick);
    }

    private void OnDisable()
    {
        MainMenu.onClick.RemoveListener(OnMainMenuButtonClick);
        Restart.onClick.RemoveListener(OnRestartButtonClick);
        _resume.onClick.RemoveListener(OnResumeButtonClick);
    }

    private void OnResumeButtonClick()
    {
        ResumeButtonClick?.Invoke();
    }

    public override void Open()
    {
        base.Open();

        _resume.interactable = true;
    }

    public override void Close()
    {
        base.Close();

        _resume.interactable = false;
    }
}
