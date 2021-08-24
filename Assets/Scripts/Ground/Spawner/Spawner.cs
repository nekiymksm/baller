using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Item[] _items;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Shifter _groundShifter;

    private void Start()
    {
        for (int i = 0; i < _items.Length; i++)
            Initialise(_items[i]);
    }

    private void Update()
    {
        if (_groundShifter.IsMove())
        {
            DisableAllObstacles();

            for (int i = 0; i < _spawnPoints.Length; i++)
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

    public void DisableAllObstacles()
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