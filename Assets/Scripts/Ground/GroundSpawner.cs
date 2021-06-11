using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _groundParts;
    [SerializeField] private Ball _ball;

    private Camera _camera;

    private float _itemLength;

    private void Start()
    {
        _camera = Camera.main;

        _itemLength = _groundParts[0].transform.lossyScale.x;
    }

    private void FixedUpdate()
    {
        if (TryToSpawn(out GameObject ground))
        {
            ground.SetActive(true);
            ground.transform.position = new Vector3(_ball.transform.position.x + 45, 0, 0);
        }

        DisableGroundAboardScreen();
    }

    private bool TryToSpawn(out GameObject ground)
    {
        ground = null;

        for (int i = 0; i < _groundParts.Length; i++)
        {
            if (_groundParts[i].activeSelf == false)
            {
                ground = _groundParts[i];

                break;
            }
        }

        return ground != null;
    }

    private void DisableGroundAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0, _itemLength));

        for (int i = 0; i < _groundParts.Length; i++)
        {
            if (_groundParts[i].activeSelf == true)
            {
                if (_groundParts[i].transform.position.x < disablePoint.x)
                    _groundParts[i].SetActive(false);
            }
        }
    }
}
