using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Ball : MonoBehaviour
{
    private int _score;
    private Vector3 _startPosition;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            IncreaseScore();

            coin.DisableYourself();
        }
        else if (collision.isTrigger)
        {
            GameOver?.Invoke();
        }
    }

    public void ResetBall()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);

        transform.position = _startPosition;
    }

    private void IncreaseScore()
    {
        _score++;

        ScoreChanged?.Invoke(_score);
    }
}
