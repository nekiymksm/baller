using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GroundShifter _groundShifter;
    [SerializeField] private SpawnSelector _spawners;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseMenu _pauseMenu;

    private Camera _camera;
    private Vector3 _cameraStartPosition;

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;

        _gameOverScreen.MainMenuButtonClick += OnMainMenuButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;

        _pauseMenu.ResumeButtonClick += GameStart;
    }

    private void OnDisable()
    {
        _ball.GameOver -= OnGameOver;

        _gameOverScreen.MainMenuButtonClick -= OnMainMenuButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;

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
        _ball.ResetBall();
        _groundShifter.ResetGround();
        _spawners.ResetSpawners();

        _camera.transform.position = _cameraStartPosition;

        GameStart();
    }

    private void GameStart()
    {
        Time.timeScale = 1;

        _gameOverScreen.Close();
        _pauseMenu.Close();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _gameOverScreen.Open();
    }

    private void OnPause()
    {
        Time.timeScale = 0;

        _pauseMenu.Open();
    }
}
