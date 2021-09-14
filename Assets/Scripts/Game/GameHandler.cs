using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GroundShifter _groundShifter;
    [SerializeField] private ItemSpawner _coinSpawner;
    [SerializeField] private ItemSpawner _barrierSpawner;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseMenuScreen _pauseMenuScreen;
    [SerializeField] private KeyCode _pauseKey;
    [SerializeField] private string _sceneNameToLoad;

    private Camera _camera;
    private Vector3 _cameraStartPosition;

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;

        _gameOverScreen.MainMenuButtonClick += OnMainMenuButtonClick;
        _gameOverScreen.TryAgainButtonClick += OnRestartButtonClick;

        _pauseMenuScreen.ResumeButtonClick += GameStart;
        _pauseMenuScreen.MainMenuButtonClick += OnMainMenuButtonClick;
        _pauseMenuScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _ball.GameOver -= OnGameOver;

        _gameOverScreen.MainMenuButtonClick -= OnMainMenuButtonClick;
        _gameOverScreen.TryAgainButtonClick -= OnRestartButtonClick;

        _pauseMenuScreen.ResumeButtonClick -= GameStart;
        _pauseMenuScreen.MainMenuButtonClick -= OnMainMenuButtonClick;
        _pauseMenuScreen.RestartButtonClick -= OnRestartButtonClick;
    }

    private void Start()
    {
        _camera = Camera.main;
        _cameraStartPosition = _camera.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey) && _gameOverScreen.gameObject.activeSelf == false)
            TurnPauseOn();
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(_sceneNameToLoad);
    }

    private void OnRestartButtonClick()
    {
        _ball.ResetBall();
        _groundShifter.ResetGround();
        _coinSpawner.DisableAllItems();
        _barrierSpawner.DisableAllItems();

        _camera.transform.position = _cameraStartPosition;

        GameStart();
    }

    private void GameStart()
    {
        Time.timeScale = 1;

        _gameOverScreen.Close();
        _pauseMenuScreen.Close();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _gameOverScreen.Open();
    }

    private void TurnPauseOn()
    {
        Time.timeScale = 0;

        _pauseMenuScreen.Open();
    }
}
