using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    /*public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDirection;
    Vector3 cameraPosition;
    public Vector3 dollyDirectionAdjusted;
    public float distance;*/

    void Awake()
    {
       /* dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;*/
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        //dollyDirection = transform.localPosition.normalized;
        //distance = transform.localPosition.magnitude;                  i know these repeat, the tutorial i watched said to put them into an Awake() but i tried putting them here too
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);

        /*Vector3 desiredPosition = transform.TransformPoint(rotation * offset);
        RaycastHit hit;
        distance = 1;
        if (Physics.Linecast(transform.position, desiredPosition, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.8f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }*/
        //transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);

        //cameraPosition = target.transform.position + (rotation * offset);
        //transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);
    }   
        //if i add this code then the camera wont stop flickering OR it will be in a random location, it depends on what i try to remove
}