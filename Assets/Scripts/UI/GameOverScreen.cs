using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameoverScreen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button MainMenu;
    [SerializeField] protected Button Restart;

    public event UnityAction RestartButtonClick;
    public event UnityAction MainMenuButtonClick;

    private void OnEnable()
    {
        MainMenu.onClick.AddListener(OnMainMenuButtonClick);
        Restart.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        MainMenu.onClick.RemoveListener(OnMainMenuButtonClick);
        Restart.onClick.RemoveListener(OnRestartButtonClick);
    }

    protected void OnMainMenuButtonClick()
    {
        MainMenuButtonClick?.Invoke();
    }

    protected void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    public virtual void Open()
    {
        CanvasGroup.alpha = 1;

        MainMenu.interactable = true;
        Restart.interactable = true;
    }

    public virtual void Close()
    {
        CanvasGroup.alpha = 0;

        MainMenu.interactable = false;
        Restart.interactable = false;
    }
}
