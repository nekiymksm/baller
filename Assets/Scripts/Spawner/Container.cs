using UnityEngine;

public class Container : MonoBehaviour
{
    private Item[] _items;

    private void Start()
    {
        _items = GetComponents<Item>();
    }

    public void DisableAllItems()
    {
        foreach (var item in _items)
            item.gameObject.SetActive(false);
    }
}
