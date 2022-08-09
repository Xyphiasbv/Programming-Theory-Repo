using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float bulletSpeed = 5.0f;
    private Rigidbody objectRb;
    private PlayerController controller;
    private Cube currentCube;
    void Start()
    {
        currentCube = GameObject.FindGameObjectWithTag("Cube").GetComponentInParent<Cube>();
        objectRb = GetComponent<Rigidbody>();
        controller = GameObject.Find("Player").GetComponent<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(objectRb == null)
        {
            transform.Translate(Vector3.up * Time.deltaTime * -bulletSpeed);
        }
        else
        {
            objectRb.AddForce(Vector3.forward*-currentCube.cubeSpeed*objectRb.mass);// ENCAPSULATION get cubeSpeed
        }
        
        if(transform.position.z < controller.lowerbound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z > controller.upperBound)
        {
            Destroy(gameObject);
        }      
    }
}
