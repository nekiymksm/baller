using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Item[] _items;
    [SerializeField] private DisablePoint _disablePoint;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _decreaseSpawnTimeOn;
    [SerializeField] private Controller _controller;

    private float _elapsedTime = 0;
    private float _startTimeBetweenSpawn;

    private void OnEnable()
    {
        _controller.IncreaseMaxSpeed += DecreaseTimeBetweenSpawn;
    }

    private void OnDisable()
    {
        _controller.IncreaseMaxSpeed -= DecreaseTimeBetweenSpawn;
    }

    private void Start()
    {
        _startTimeBetweenSpawn = _timeBetweenSpawn;

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

            ReActivateObstacleChilds(item);

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

    private void ReActivateObstacleChilds(Item item)
    {
        for (int i = 0; i < item.transform.childCount; i++)
            item.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void DisableAllObstacles()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    private void DecreaseTimeBetweenSpawn()
    {
        _timeBetweenSpawn -= _decreaseSpawnTimeOn;
    }

    public void ResetTimeBetweenSpawn()
    {
        _timeBetweenSpawn = _startTimeBetweenSpawn;
    }
}