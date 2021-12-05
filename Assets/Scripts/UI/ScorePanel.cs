using TMPro;
using UnityEngine;

public class ScorePanel : Screen
{
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _ball.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _ball.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
