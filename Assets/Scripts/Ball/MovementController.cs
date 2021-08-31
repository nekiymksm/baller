using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _timeToIncreaseSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _minJumpPermission;

    private Rigidbody _rigidbody;

    private float _startingMaxSpeed;
    private float _elapsedTime = 0;

    public event UnityAction IncreaseMaxSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _minJumpPermission += transform.position.y;

        _startingMaxSpeed = _maxSpeed;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        MaxSpeedIncrease();
    }

    private void FixedUpdate()
    {
        Roll();
        Jump();
    }

    private void Roll()
    {
        if (_rigidbody.velocity.magnitude <= _maxSpeed)
            _rigidbody.AddForce(Vector3.right, ForceMode.Impulse);
    }

    private void Jump()
    {
        if (_rigidbody.position.y <= _minJumpPermission)
            _rigidbody.AddForce(new Vector3(0, Input.GetAxis("Fire1"), 0) * _jumpForce, ForceMode.Impulse);
    }

    private void MaxSpeedIncrease()
    {
        if (_elapsedTime >= _timeToIncreaseSpeed)
        {
            _maxSpeed += 1;
            _elapsedTime = 0;

            IncreaseMaxSpeed?.Invoke();
        }
    }

    public void MaxSpeedReset()
    {
        _maxSpeed = _startingMaxSpeed;
    }
}
