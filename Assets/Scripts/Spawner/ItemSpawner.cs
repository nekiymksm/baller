using UnityEngine;

public abstract class ItemSpawner : ObjectsPool
{
    [SerializeField] private DisablePoint _disablePoint;

    private void Start()
    {
        InitialiseItems();
    }

    private void Update()
    {
        DisableItemsOffScreen();
    }

    public abstract void InitialiseItems();

    public abstract void SpawnItem();

    private void DisableItemsOffScreen()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (Pool[i].transform.position.x <= _disablePoint.transform.position.x)
                Pool[i].gameObject.SetActive(false);
        }
    }

    public void DisableAllItems()
    {
        foreach (var item in Pool)
            item.gameObject.SetActive(false);
    }
}
