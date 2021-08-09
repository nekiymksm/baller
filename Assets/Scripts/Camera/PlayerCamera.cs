using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public void ResetCameraPosition()
    {
        transform.position = new Vector3(5, 5, -7);
    }
}
