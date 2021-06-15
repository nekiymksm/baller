using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundReMover : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _xAxisExtractionPointer;
    [SerializeField] private float _xAxisSpawnPointer;

    private bool _isReSpawn;

    private void Update()
    {
        if (_ball.transform.position.x >= transform.position.x + _xAxisExtractionPointer)
        {
            transform.position = new Vector3(_ball.transform.position.x + _xAxisSpawnPointer, 0, 0);

            _isReSpawn = true;
        }
        else
        {
            _isReSpawn = false;
        }
    }

    public bool IsReSpawn()
    {
        return _isReSpawn;
    }
}
