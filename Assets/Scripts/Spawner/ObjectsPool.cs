using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Container _container;

    private List<Item> _pool = new List<Item>();

    public void Initialise(Item prefab)
    {
        Item item = Instantiate(prefab, _container.transform);
        item.gameObject.SetActive(false);

        _pool.Add(item);
    }

    public Item TryGetObject()
    {
        Item item;

        do item = _pool[Random.Range(0, _pool.Count)];
        while (item.gameObject.activeSelf == true);

        return item;
    }
}
