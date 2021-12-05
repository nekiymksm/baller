using UnityEngine;

public class GroundShifter : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ExtractionPoint _extractionPoint;
    [SerializeField] private InstallationPoint _installationPoint;

    private void Update()
    {
        ShiftGround();
    }

    private void ShiftGround()
    {
        if (_ball.transform.position.x >= _extractionPoint.transform.position.x)
            transform.position = _installationPoint.transform.position;
    }
}
