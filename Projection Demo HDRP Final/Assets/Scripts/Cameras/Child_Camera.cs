using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Camera : MonoBehaviour
{
    public GameObject target;
    public Transform camera;
    Vector3 offset;
    Vector3 cameraDirection;
    public float cameraDistance;
    public Vector2 cameraDistanceMinMax = new Vector2(0.5f, 5f);

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        cameraDirection = transform.localPosition.normalized;
        cameraDistance = cameraDistanceMinMax.y;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        CheckCameraOcclusionAndCollision(camera);
        //transform.position = target.transform.position + (rotation * offset);
        //transform.LookAt(target.transform);
    }

    public void CheckCameraOcclusionAndCollision(Transform camera)
    {

        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, desiredCameraPosition, out hit))
        {
            cameraDistance = Mathf.Clamp(hit.distance * 0.9f, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
        }
        else
        {
            cameraDistance = cameraDistanceMinMax.y;
        }
        camera.localPosition = cameraDirection + target.transform.position * cameraDistance;
        //transform.position = cameraDirection * (cameraDistance - 0.1f);
        //Debug.DrawLine(transform.position, desiredCamPosition)
    }
}
