using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceCamera : MonoBehaviour
{
    public InheritanceCamera cam;
    public GameObject target;
    Vector3 cameraDirection;

    public float camDistance;
    public Vector3 CameraDisMinMax = new Vector2(0.5f, 5f);

    // Start is called before the first frame update
    void Start()
    {
        cameraDirection = transform.localPosition.normalized;
        camDistance = CameraDisMinMax.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.5f);
        CheckCollision(cam);
    }
    public void CheckCollision(InheritanceCamera camera)
    {
        Vector3 desiredCamPos = transform.TransformPoint(cameraDirection * 3);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, desiredCamPos, out hit))
        {
            camDistance = Mathf.Clamp(hit.distance * 0.8f, CameraDisMinMax.x, CameraDisMinMax.y);
        }
        else
        {
            camDistance = CameraDisMinMax.y;
        }
        cam.transform.localPosition = cameraDirection * (camDistance - 0.1f);
    }
}
