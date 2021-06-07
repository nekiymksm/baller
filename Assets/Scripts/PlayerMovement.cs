using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
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
        GetMove();
        GetJump();
    }

    private void GetMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(0, 0, moveHorizontal);

        if (_rigidbody.velocity.magnitude <= _maxSpeed)
            _rigidbody.AddForce(moveDirection * _moveSpeed, ForceMode.Force);
    }

    private void GetJump()
    {
        float moveUp = Input.GetAxis("Jump");

        Vector3 moveDirection = new Vector3(0, moveUp, 0);

        if (_rigidbody.position.y <= _minJumpPermission)
            _rigidbody.AddForce(moveDirection * _jumpForce, ForceMode.Impulse);
    }
}
