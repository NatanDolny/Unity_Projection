using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_At_Camera : MonoBehaviour
{
    public GameObject target;
    void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
