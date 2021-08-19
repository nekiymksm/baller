using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ReMover _reMover;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private Camera _camera;
    private Vector3 _cameraStartPosition;

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
        _camera = Camera.main;
        _cameraStartPosition = _camera.transform.position;

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

        _camera.transform.position = _cameraStartPosition;

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
