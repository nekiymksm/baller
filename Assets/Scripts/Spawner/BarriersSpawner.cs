using UnityEngine;

public class BarriersSpawner : ItemSpawner
{
    [SerializeField] private Barrier[] _barriers;

    protected override void InitialiseItems()
    {
        for (int i = 0; i < _barriers.Length; i++)
            ObjectsPool.Initialise(_barriers[i]);
    }

    protected override void SpawnItem()
    {
        if (ElapsedTime >= TimeBetweenSpawn)
        {
            Item barrier = ObjectsPool.TryGetObject();

            barrier.gameObject.SetActive(true);
            barrier.transform.position = SpawnPointers[Random.Range(0, SpawnPointers.Length)].transform.position;

            ElapsedTime = 0;
        }
    }
}
