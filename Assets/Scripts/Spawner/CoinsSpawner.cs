using UnityEngine;

public class CoinsSpawner : ItemSpawner
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _coinsAmount;
    [SerializeField] private float _distanceBetweenCoins;

    protected override void InitialiseItems()
    {
        for (int i = 0; i < _coinsAmount; i++)
            ObjectsPool.Initialise(_coin);
    }

    protected override void SpawnItem()
    {
        if (ElapsedTime >= TimeBetweenSpawn)
        {
            float yAxis = SpawnPointers[Random.Range(0, 1)].transform.position.y;

            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                Item coin = ObjectsPool.TryGetObject();

                coin.gameObject.SetActive(true);
                coin.transform.position = new Vector3(transform.position.x + i * _distanceBetweenCoins, yAxis, transform.position.z);

                ElapsedTime = 0;
            }
        }
    }
}
