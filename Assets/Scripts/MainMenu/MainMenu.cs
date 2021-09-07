using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayAnimation(false);

            if (_animators[0].GetCurrentAnimatorStateInfo(0).loop)
                ChangeButtonsState(true);
        }
    }

    public void OnPlayButtonClick(string levelLabel)
    {
        SceneManager.LoadScene(levelLabel);
    }

    public void OnCreatorsButtonClick()
    {
        PlayAnimation(true);
        ChangeButtonsState(false);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void PlayAnimation(bool condition)
    {
        foreach (var animator in _animators)
            animator.SetBool("IsOpen", condition);
    }

    private void ChangeButtonsState(bool condition)
    {
        foreach (var button in _buttons)
            button.interactable = condition;
    }
}
