using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private ReMover _groundReMover;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        for (int i = 0; i < _prefabs.Length; i++)
            Initialise(_prefabs[i]);
    }

    private void Update()
    {
        if (_groundReMover.IsMove())
        {
            if (TryGetObject(out GameObject item))
            {
                item.SetActive(true);
                item.transform.position = transform.position;
            }
        }

        DisablePrefabsAboardScreen();
    }

    private void DisablePrefabsAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0, 10));

        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].activeSelf == true)
            {
                if (_pool[i].transform.position.x < disablePoint.x)
                    _pool[i].SetActive(false);
            }
        }
    }
}
