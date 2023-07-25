using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera_With_Collision : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObject;
    Vector3 followPosition;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject CameraObject;
    public GameObject PlayerObject;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputY;
    public float smoothX;
    public float smoothY;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotationX = rotation.x;
        rotationY = rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("Rotation");
        finalInputY = inputY;

        rotationY += finalInputY * inputSensitivity * Time.deltaTime; // potentially wrong here
       
        rotationY = Mathf.Clamp(rotationY, -clampAngle, clampAngle);
        Quaternion localRotation = Quaternion.Euler(rotationY, rotationY, 0.0f);
        transform.rotation = localRotation;
    }

    void LateUpdate()
    {
        CameraUpdater();
    }
    void CameraUpdater()
    {
        Transform target = CameraFollowObject.transform;
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }
}
