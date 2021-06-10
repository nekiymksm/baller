using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float _points = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _points++;
        }
    }
}
