using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _ground;

    private Camera _camera;

    private void Update()
    {
        if (TryToSpawn(out GameObject ground))
        {
            ground.SetActive(true);
            ground.transform.position = new Vector3(transform.parent.position.x + 55, -1.5f, 0);
        }

        DisableGroundAboardScreen();
    }

    private bool TryToSpawn(out GameObject ground)
    {
        ground = null;

        for (int i = 0; i < _ground.Length; i++)
        {
            if (_ground[i].activeSelf == false)
            {
                ground = _ground[i];

                break;
            }
        }

        return ground != null;
    }

    private void DisableGroundAboardScreen()
    {
        _camera = Camera.main;

        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0, 25));

        for (int i = 0; i < _ground.Length; i++)
        {
            if (_ground[i].activeSelf == true)
            {
                if (_ground[i].transform.position.x < disablePoint.x)
                {
                    _ground[i].SetActive(false);
                }
            }
        }
    }
}
