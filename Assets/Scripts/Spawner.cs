using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        for (int i = 0; i < _prefabs.Length; i++)
        {
            Initialise(_prefabs[i]);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject item))
            {
                _elapsedTime = 0;

                item.SetActive(true);
                item.transform.position = transform.position;
            }
        }
    }
}
