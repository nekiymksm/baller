using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _minJumpPermission;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _minJumpPermission += transform.position.y;
    }

    private void FixedUpdate()
    {
        TryJump();
    }

    private void TryJump()
    {
        float moveUp = Input.GetAxis("Jump");

        Vector3 moveDirection = new Vector3(0, moveUp, 0);

        if (_rigidbody.position.y <= _minJumpPermission)
            _rigidbody.AddForce(moveDirection * _jumpForce, ForceMode.Impulse);
    }
}
