using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Shifter _shifter;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Controller _controller;
    [SerializeField] private GameoverScreen _gameoverScreen;
    [SerializeField] private PauseMenu _pauseMenu;

    private Camera _camera;
    private Vector3 _cameraStartPosition;

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;

        _gameoverScreen.MainMenuButtonClick += OnMainMenuButtonClick;
        _gameoverScreen.RestartButtonClick += OnRestartButtonClick;

        _pauseMenu.ResumeButtonClick += GameStart;
    }

    private void OnDisable()
    {
        _ball.GameOver -= OnGameOver;

        _gameoverScreen.MainMenuButtonClick -= OnMainMenuButtonClick;
        _gameoverScreen.RestartButtonClick -= OnRestartButtonClick;

        _pauseMenu.ResumeButtonClick -= GameStart;
    }

    private void Start()
    {
        _camera = Camera.main;
        _cameraStartPosition = _camera.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnPause();
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRestartButtonClick()
    {
        _ball.BallReset();
        _shifter.GroundReset();
        _spawner.DisableAllObstacles();
        _spawner.ResetTimeBetweenSpawn();
        _controller.MaxSpeedReset();

        _camera.transform.position = _cameraStartPosition;

        GameStart();
    }

    private void GameStart()
    {
        Time.timeScale = 1;

        _gameoverScreen.Close();
        _pauseMenu.Close();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _gameoverScreen.Open();
    }

    private void OnPause()
    {
        Time.timeScale = 0;

        _pauseMenu.Open();
    }
}
