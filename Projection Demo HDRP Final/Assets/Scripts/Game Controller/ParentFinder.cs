using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFinder : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnCollisionEExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
