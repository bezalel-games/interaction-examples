using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePositionLive : MonoBehaviour
{
    public Transform Target;
    public float Duration = 1f;
    public AnimationCurve Curve;
    
    private Vector3 _startPosition;
    private Coroutine _animation;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_animation != null)
                StopCoroutine(_animation);
            
            _animation = StartCoroutine(Animate());
        }
    }

    IEnumerator Animate()
    {
        Vector3 translation = Target.position - _startPosition;
        
        for (float time = 0f; time <= Duration; time += Time.deltaTime)
        {
            float ratio = time / Duration;

            float t = Curve.Evaluate(ratio);
            
            transform.position = _startPosition + translation * t; 
            yield return null;
        }

        transform.position = Target.position;
    }
}
