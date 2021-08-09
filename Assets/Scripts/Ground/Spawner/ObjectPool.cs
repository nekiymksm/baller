using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float _capacity;

    protected List<Item> _pool = new List<Item>();

    protected void Initialise(Item prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Item item = Instantiate(prefab, transform);
            item.gameObject.SetActive(false);

            _pool.Add(item);
        }
    }

    protected bool TryGetObject(out Item result)
    {
        Item item;

        result = null;

        while (result == null)
        {
            item = _pool[Random.Range(0, _pool.Count)];

            if (item.gameObject.activeSelf == false)
                result = item;
        }

        return result != null;
    }
}
