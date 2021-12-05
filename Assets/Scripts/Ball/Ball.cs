using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Ball : MonoBehaviour
{
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

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

    private void IncreaseScore()
    {
        _score++;

        ScoreChanged?.Invoke(_score);
    }
}
