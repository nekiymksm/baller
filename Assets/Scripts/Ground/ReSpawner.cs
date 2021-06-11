using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _extractionPoint;
    [SerializeField] private float _respawnPoint;

    private void Update()
    {
        if (_ball.transform.position.x >= transform.position.x + _extractionPoint)
            transform.position = new Vector3(_ball.transform.position.x + _respawnPoint, 0, 0);
    }    
}
