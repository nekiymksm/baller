using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseMenuScreen _pauseMenuScreen;
    [SerializeField] private KeyCode _pauseKey;

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _ball.GameOver -= OnGameOver;
    }

    private void Update()
    {
        TryTurnPauseOn();
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
    }

    private void TryTurnPauseOn()
    {
        if (Input.GetKeyDown(_pauseKey) && _gameOverScreen.gameObject.activeSelf == false)
            _pauseMenuScreen.Open();
    }
}
