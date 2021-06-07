using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private float _step;
    [SerializeField] private float _indent;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, _object.transform.position.z + _indent), _step * Time.deltaTime);
    }
}
