using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    
    void Awake()
    {
        liveCam = Camera.allCameras[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        if (other == PlayerCollider)
        {
            triggeredCam.enabled = true;
            liveCam.enabled = false;

            liveCam = Camera.allCameras[0];

            triggeredCam.GetComponent<AudioListener>().enabled = true;
            PlayerCharacter.GetComponent<AudioListener>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {

    }
}
