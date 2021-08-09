using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ReMover _reMover;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PlayerCamera _camera;

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;
        _gameOverScreen.MainMenuButtonClick += OnMainMenuButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _ball.GameOver -= OnGameOver;
        _gameOverScreen.MainMenuButtonClick -= OnMainMenuButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRestartButtonClick()
    {
        _ball.BallReset();
        _reMover.GroundReset();
        _camera.ResetCameraPosition();
        GameStart();
    }

    private void GameStart()
    {
        Time.timeScale = 1;

        _gameOverScreen.Close();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _gameOverScreen.Open();
    }
}
