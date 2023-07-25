using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    public Transform holdingPoint;
    public Transform leverPoint;
    public float maxDistance = 1.0f;

    private bool inputP;
    private bool pickedUp = false;
    private float rotation;
    private float PToHDifference;
    private float PToLDifference;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float rotationZ = 0.0f;

    void Update()
    {
        inputP = Input.GetButton("Pick Up");
        if (inputP)
        {
            pickedUp = !pickedUp;
        }
        PDown();
    }

    void PDown()
    {
        PToHDifference = Vector3.Distance(this.transform.position, holdingPoint.transform.position);
        PToLDifference = Vector3.Distance(this.transform.position, leverPoint.transform.position);


        if (pickedUp == true & PToHDifference <= maxDistance)
        {
            this.transform.parent = GameObject.Find("LeftHandPoint").transform;
            rotationX = rotationX + transform.parent.rotation.x;
            rotationY = rotationY + transform.parent.rotation.y; ;
            rotationZ = rotationZ + transform.parent.rotation.z; ;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = holdingPoint.position;
            this.transform.localRotation = Quaternion.Euler(rotationX, 0, rotationZ);
        }
        else if (!pickedUp)
        {
            if (PToLDifference <= 1)
            {
                this.transform.parent = GameObject.Find("Lever").transform;
                this.transform.position = leverPoint.position;
            }
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
