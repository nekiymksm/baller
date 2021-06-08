using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (transform.position.z >= -10)
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        else 
            transform.position = new Vector3(0, 0, 10);
    }
}
