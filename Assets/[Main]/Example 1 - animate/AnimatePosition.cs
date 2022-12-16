using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimatePosition : MonoBehaviour
{
    public Transform TargetPose;
    public float Duration = 1f;
    public AnimationCurve Curve = AnimationCurve.Linear(0f,0f,1f,1f);
    
    Vector3 _startPosition;
    Coroutine _animation = null;
    bool _reverse = false;
    
    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            PlayAnimation();
    }

    void PlayAnimation()
    {
        // Stop if already playing
        if (_animation != null)
            StopCoroutine(_animation);

        _animation = StartCoroutine(Animate(_reverse));
        _reverse = !_reverse;
    }
    
    IEnumerator Animate(bool reverse)
    {
        Vector3 from = _startPosition;
        Vector3 to = TargetPose.position;

        if (reverse)
        {
            (from, to) = (to, from);
        }
        
        for (float time = 0f; time < Duration; time += Time.deltaTime)
        {
            float t = Curve.Evaluate(time / Duration);
            transform.position = Vector3.Lerp(from, to, t);
            yield return null;
        }

        transform.position = TargetPose.position;
    }
}
