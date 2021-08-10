using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Item[] _items;
    [SerializeField] private ReMover _groundReMover;
    [SerializeField] private float _zCameraProjectionPointer;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        for (int i = 0; i < _items.Length; i++)
            Initialise(_items[i]);
    }

    private void Update()
    {
        if (_groundReMover.IsMove())
        {
            if (TryGetObject(out Item item))
            {
                item.gameObject.SetActive(true);
                item.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;

                for (int i = 0; i < item.transform.childCount; i++)
                    item.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        DisablePrefabsAboardScreen();
    }

    private void DisablePrefabsAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0, _zCameraProjectionPointer));

        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].gameObject.activeSelf == true)
            {
                if (_pool[i].transform.position.x <= disablePoint.x)
                    _pool[i].gameObject.SetActive(false);
            }
        }
    }
}
