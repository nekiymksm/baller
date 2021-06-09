using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
