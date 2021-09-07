using UnityEngine;

public class CoinsSpawner : ItemSpawner
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _coinsAmount;
    [SerializeField] private float _distanceBetweenCoins;

    public override void InitialiseItems()
    {
        for (int i = 0; i < _coinsAmount; i++)
            Initialise(_coin);
    }

    public override void SpawnItem()
    {
        for (int i = 0; i < Random.Range(0, 4); i++)
        {
            if (TryGetObject(out Item coin))
            {
                coin.gameObject.SetActive(true);
                coin.transform.position = new Vector3(transform.position.x + i * _distanceBetweenCoins, transform.position.y, transform.position.z);
            }
        }
    }
}
