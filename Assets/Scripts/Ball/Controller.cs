using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Controller : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
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
        Roll();
        TryJump();
    }

    private void Roll()
    {
        if (_rigidbody.velocity.magnitude <= _maxSpeed)
            _rigidbody.AddForce(Vector3.right, ForceMode.Impulse);
    }

    private void TryJump()
    {
        float jump = Input.GetAxis("Fire1");

        Vector3 moveUp = new Vector3(0, jump, 0);

        if (_rigidbody.position.y <= _minJumpPermission)
            _rigidbody.AddForce(moveUp * _jumpForce, ForceMode.Impulse);
    }
}
