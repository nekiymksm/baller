using UnityEngine;

public class BarriersSpawner : ItemSpawner
{
    [SerializeField] private Barrier[] _barriers;

    public override void InitialiseItems()
    {
        for (int i = 0; i < _barriers.Length; i++)
            Initialise(_barriers[i]);
    }

    public override void SpawnItem()
    {
        if (TryGetObject(out Item barrier))
        {
            barrier.gameObject.SetActive(true);
            barrier.transform.position = transform.position;
        }
    }
}
