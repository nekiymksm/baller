using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Item[] _items;
    [SerializeField] private DisablePoint _disablePoint;
    [SerializeField] private MovementController _movementController;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _spawnTimeReductionUnit;

    private float _elapsedTime = 0;
    private float _startingTimeBetweenSpawn;

    private void OnEnable()
    {
        _movementController.IncreaseMaxSpeed += DecreaseTimeBetweenSpawn;
    }

    private void OnDisable()
    {
        _movementController.IncreaseMaxSpeed -= DecreaseTimeBetweenSpawn;
    }

    private void Start()
    {
        _startingTimeBetweenSpawn = _timeBetweenSpawn;

        for (int i = 0; i < _items.Length; i++)
            Initialise(_items[i]);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        SpawnObstacle();
        DisableObstaclesOffScreen();
    }

    private void SpawnObstacle()
    {
        if (_elapsedTime >= _timeBetweenSpawn && TryGetObject(out Item item))
        {
            item.gameObject.SetActive(true);
            item.transform.position = transform.position;

            ActivateObstacleChilds(item);

            _elapsedTime = 0;
        }
    }

    private void DisableObstaclesOffScreen()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].transform.position.x <= _disablePoint.transform.position.x)
                _pool[i].gameObject.SetActive(false);
        }
    }

    private void ActivateObstacleChilds(Item item)
    {
        for (int i = 0; i < item.transform.childCount; i++)
            item.transform.GetChild(i).gameObject.SetActive(true);
    }

    private void DecreaseTimeBetweenSpawn()
    {
        _timeBetweenSpawn -= _spawnTimeReductionUnit;
    }

    public void DisableAllObstacles()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    public void ResetTimeBetweenSpawn()
    {
        _timeBetweenSpawn = _startingTimeBetweenSpawn;
    }
}