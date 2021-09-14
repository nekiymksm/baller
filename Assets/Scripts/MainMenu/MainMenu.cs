using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OnPlayButtonClick(string levelLabel)
    {
        SceneManager.LoadScene(levelLabel);
    }

    public void OnCreatorsButtonClick()
    {
        PlayAnimation(true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnDisableCurtainButtonClick()
    {
        PlayAnimation(false);
    }

    private void PlayAnimation(bool condition)
    {
        foreach (var animator in _animators)
            animator.SetBool("IsOpen", condition);
    }
}
