using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShifter : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ExtractionPoint _extractionPoint;
    [SerializeField] private InstallationPoint _installationPoint;

    private Vector3 _groundStartPosition;

    private void Start()
    {
        _groundStartPosition = transform.position;
    }

    private void Update()
    {
        if (_ball.transform.position.x >= _extractionPoint.transform.position.x)
            transform.position = _installationPoint.transform.position;
    }

    public void GroundReset()
    {
        transform.position = _groundStartPosition;
    }
}
