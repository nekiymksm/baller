using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected Container _container;

    protected List<Item> _pool = new List<Item>();

    protected void Initialise(Item prefab)
    {
        Item item = Instantiate(prefab, _container.transform);
        item.gameObject.SetActive(false);

        _pool.Add(item);
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
