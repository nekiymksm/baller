using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Item[] _items;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private ReMover _groundReMover;

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
            DisableAllObstacles();

            for (int i = 0; i < 3; i++)
            {
                if (TryGetObject(out Item item))
                {
                    item.gameObject.SetActive(true);
                    item.transform.position = _spawnPoints[i].transform.position;

                    ReActivateObstacleChilds(item);
                }
            } 
        }
    }

    private void DisableAllObstacles()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    private void ReActivateObstacleChilds(Item item)
    {
        for (int i = 0; i < item.transform.childCount; i++)
            item.transform.GetChild(i).gameObject.SetActive(true);
    }
}