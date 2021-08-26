using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Controller : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _timeToSpeedIncrease;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _minJumpPermission;

    private Rigidbody _rigidbody;
    private float _startMaxSpeed;
    private float _elapsedTime = 0;

    public event UnityAction IncreaseMaxSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _minJumpPermission += transform.position.y;

        _startMaxSpeed = _maxSpeed;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        MaxSpeedIncrease();
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

    private void MaxSpeedIncrease()
    {
        if (_elapsedTime >= _timeToSpeedIncrease)
        {
            _maxSpeed += 1;
            _elapsedTime = 0;

            IncreaseMaxSpeed?.Invoke();
        }
    }

    public void MaxSpeedReset()
    {
        _maxSpeed = _startMaxSpeed;
    }
}
