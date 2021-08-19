using System.Collections;
using System.Collections.Generic;
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

            coin.gameObject.SetActive(false);
        }
        else if (collision.isTrigger)
        {
            Die();
        }
    }

    public void BallReset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);

        transform.position = new Vector3(0, 1.8f, 0);
    }

    private void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void Die()
    {
        GameOver?.Invoke();
    }
}
