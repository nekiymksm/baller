using UnityEngine;

public class SpawnSelector : MonoBehaviour
{
    [SerializeField] private ItemSpawner[] _spawners;
    [SerializeField] private float _timeBetweenSpawn;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        TryToSpawnItem();
    }

    private void TryToSpawnItem()
    {
        if (_elapsedTime >= _timeBetweenSpawn)
        {
            _spawners[Random.Range(0, _spawners.Length)].SpawnItem();

            _elapsedTime = 0;
        }
    }

    public void ResetSpawners()
    {
        for (int i = 0; i < _spawners.Length; i++)
            _spawners[i].DisableAllItems();
    }
}
