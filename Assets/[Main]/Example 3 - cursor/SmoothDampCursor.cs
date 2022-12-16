using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Plane = UnityEngine.Plane;
using Vector3 = UnityEngine.Vector3;

public class SmoothDampCursor : MonoBehaviour
{
    public float DampingTime = 0.2f;

    Vector3 _velocity = Vector3.zero;
    Vector3 _target;
    Plane _motionPlane;

    void Start()
    {
        _target = transform.position;
        _motionPlane = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_motionPlane.Raycast(ray, out float distance))
            _target = ray.GetPoint(distance);

        transform.position = Vector3.SmoothDamp(transform.position, _target, ref _velocity, DampingTime);
    }
}
