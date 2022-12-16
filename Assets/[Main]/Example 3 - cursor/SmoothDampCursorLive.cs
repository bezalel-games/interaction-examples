using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Plane = UnityEngine.Plane;
using Vector3 = UnityEngine.Vector3;

public class SmoothDampCursorLive : MonoBehaviour
{
    public float Damping = 1f;
    
    private Plane _plane;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _target;
    
    private void Start()
    {
        _target = transform.position;
        _plane = new Plane(Vector3.up, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (_plane.Raycast(ray, out float distance))
        {
            _target = ray.GetPoint(distance);
        }
        
        // Check if not starting too quick
        Vector3 currentTarget = (_target-transform.position).magnitude < 5 ?
            _target:
            
        
        transform.position = Vector3.SmoothDamp(
            transform.position,
            _target, ref _velocity,
            Damping);
    }
}
