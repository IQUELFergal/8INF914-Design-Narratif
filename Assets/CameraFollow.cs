using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Object to follow
    public Transform target;

    //Set to z -8
    public Vector3 offset = new Vector3(0,0,-8);

    //How much delay on the follow
    [Range(1, 10)]
    public float smoothing = 10f;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}

