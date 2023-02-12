using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private float animationTime = 10f; // time in seconds for the animation
    private float startTime;
    private float currentValue;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float t = elapsedTime / animationTime;
        t = t - Mathf.Floor(t);
        currentValue = Mathf.Lerp(-1, 1, t * 2f);
        if (t >= 0.5f)
        {
            currentValue = Mathf.Lerp(1, -1, (t - 0.5f) * 2f);
        }
        transform.localScale = new Vector3(currentValue, 1, 1);
    }
}
