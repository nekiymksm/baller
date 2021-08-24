using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shifter : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ExtractionPoint _extractionPoint;
    [SerializeField] private InstallationPoint _installationPoint;

    private void Update()
    {
        if (_ball.transform.position.x >= _extractionPoint.transform.position.x)
            transform.position = _installationPoint.transform.position;
    }

    public void GroundReset()
    {
        transform.position = new Vector3(15, 0, 0);
    }
}
