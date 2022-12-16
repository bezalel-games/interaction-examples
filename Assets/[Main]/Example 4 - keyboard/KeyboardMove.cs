using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Plane = UnityEngine.Plane;
using Vector3 = UnityEngine.Vector3;

public class KeyboardMove : MonoBehaviour
{
    public float Speed = 0.1f;
    public float DampingTime = 0.2f;

    Vector3 _velocity = Vector3.zero;
    Vector3 _target;

    void Start()
    {
        _target = transform.position;
    }

    void Update()
    {
        Vector3 dir = GetDirectionFromInput();
        _target += dir * (Speed * Time.deltaTime); 
        
        transform.position = Vector3.SmoothDamp(transform.position, _target, ref _velocity, DampingTime);
    }

    Vector3 GetDirectionFromInput()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }

        // Always normalize the vector if you're going to use it as a direction only! (not a translation)
        return direction.normalized;
    }
}
