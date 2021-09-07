using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Container _container;

    protected List<Item> Pool = new List<Item>();

    protected void Initialise(Item prefab)
    {
        Item item = Instantiate(prefab, _container.transform);
        item.gameObject.SetActive(false);

        Pool.Add(item);
    }

    protected bool TryGetObject(out Item result)
    {
        Item item;

        result = null;

        while (result == null)
        {
            item = Pool[Random.Range(0, Pool.Count)];

            if (item.gameObject.activeSelf == false)
                result = item;
        }

        return result != null;
    }
}
