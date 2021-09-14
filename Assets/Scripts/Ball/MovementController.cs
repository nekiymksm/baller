using UnityEngine;

[RequireComponent(typeof(Ball))]
[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
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
        MoveForward();
        TryJump();
    }

    private void MoveForward()
    {
        if (_rigidbody.velocity.magnitude <= _maxSpeed)
            _rigidbody.AddForce(Vector3.right, ForceMode.Impulse);
    }

    private void TryJump()
    {
        if (_rigidbody.position.y <= _minJumpPermission)
            _rigidbody.AddForce(new Vector3(0, Input.GetAxis("Fire1"), 0) * _jumpForce, ForceMode.Impulse);
    }
}
