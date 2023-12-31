﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Collision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDirection;
    public Vector3 dollyDirectionAdjusted;
    public float distance;

    // Start is called before the first frame update
    void Awake()
    {
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = transform.parent.TransformPoint(dollyDirection * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast (transform.parent.position, desiredPosition, out hit))
        {
            distance = Mathf.Clamp((hit.distance*0.8f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);

    }
}
