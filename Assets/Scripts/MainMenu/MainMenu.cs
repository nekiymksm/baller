using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Play(string levelLabel)
    {
        SceneManager.LoadScene(levelLabel);
    }

    public void Autors(Animator animator)
    {
        animator.SetBool("IsOpen", !animator.GetBool("IsOpen"));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
