using UnityEngine;

[RequireComponent(typeof(ObjectsPool))]
public abstract class ItemSpawner : MonoBehaviour
{
    [SerializeField] protected SpawnPointer[] SpawnPointers;
    [SerializeField] protected float TimeBetweenSpawn;

    protected ObjectsPool ObjectsPool;
    protected float ElapsedTime = 0;

    private void Start()
    {
        ObjectsPool = GetComponent<ObjectsPool>();

        InitialiseItems();
    }

    private void Update()
    {
        ElapsedTime += Time.deltaTime;

        SpawnItem();
    }

    protected abstract void InitialiseItems();

    protected abstract void SpawnItem();
}
