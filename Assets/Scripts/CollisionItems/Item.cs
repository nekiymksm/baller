using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
    }

    protected void Move()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
