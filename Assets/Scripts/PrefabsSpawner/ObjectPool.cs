using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialise(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject item = Instantiate(prefab, transform);
            item.SetActive(false);

            _pool.Add(item);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        GameObject item;

        result = null;

        while (result == null)
        {
            item = _pool[Random.Range(0, _pool.Count)];

            if (item.activeSelf == false)
                result = item;
        }

        return result != null;
    }

    //private void DisableGroundAboardScreen()
    //{
    //    Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0, _itemLength));

    //    for (int i = 0; i < _groundParts.Length; i++)
    //    {
    //        if (_groundParts[i].activeSelf == true)
    //        {
    //            if (_groundParts[i].transform.position.x < disablePoint.x)
    //                _groundParts[i].SetActive(false);
    //        }
    //    }
    //}
}
