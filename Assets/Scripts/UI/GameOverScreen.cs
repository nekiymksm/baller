using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _restart;

    public event UnityAction RestartButtonClick;
    public event UnityAction MainMenuButtonClick;

    private void OnEnable()
    {
        _mainMenu.onClick.AddListener(OnMainMenuButtonClick);
        _restart.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _mainMenu.onClick.RemoveListener(OnMainMenuButtonClick);
        _restart.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnMainMenuButtonClick()
    {
        MainMenuButtonClick?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _mainMenu.interactable = true;
        _restart.interactable = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _mainMenu.interactable = false;
        _restart.interactable = false;
    }
}
