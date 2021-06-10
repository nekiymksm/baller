using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialise(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject prefabUnit = Instantiate(prefab, transform);
            prefabUnit.SetActive(false);

            _pool.Add(prefabUnit);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = null;

        GameObject spawnedItem;

        while (result == null)
        {
            spawnedItem = _pool[Random.Range(0, _pool.Count)];

            if (spawnedItem.activeSelf == false)
                result = spawnedItem;
        }

        return result;
    }
}
