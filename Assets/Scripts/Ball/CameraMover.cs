using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _centeringSpeed;
    [SerializeField] private float _xAxisIndent;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_ball.transform.position.x - _xAxisIndent, transform.position.y, transform.position.z), _centeringSpeed);
    }
}
