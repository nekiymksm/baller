using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        _rigidbody.MoveRotation(Quaternion.AngleAxis(1 * _speed, Vector3.right) * transform.rotation);
    }
}
