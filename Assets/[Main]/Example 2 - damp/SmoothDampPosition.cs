using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampPosition : MonoBehaviour
{
    public Transform TargetPose;
    public float DampingTime = 1f;

    Vector3 _startPosition;
    Vector3 _velocity = Vector3.zero;
    Vector3 _target;
    bool _reverse = false;

    void Start()
    {
        _target = _startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _target = _reverse ? _startPosition : TargetPose.position;
            _reverse = !_reverse;
        }

        transform.position = Vector3.SmoothDamp(transform.position, _target, ref _velocity, DampingTime);
    }
}
