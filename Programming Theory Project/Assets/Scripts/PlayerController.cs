using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private float speed = 10.0f;
    public int numberOfBullets;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;  
    public float upperBound = 20.0f;
    public float lowerbound = -20.0f; 
    public bool gameOver;
    private Rigidbody playerRb;
    public GameObject bulletPrefab;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
           
    }

    // Update is called once per frame
    void Update()
    {
        ConstraintPlayer();// ABSTRACTION
        MovePlayer();// ABSTRACTION
        if(Input.GetKeyDown(KeyCode.LeftShift) && numberOfBullets > 0)
        {
            FireBullets();
            numberOfBullets--;
        }    
    }

    private void OnCollisionEnter(Collision other) 
    {        
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if(other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("I'm hit");
        }    
    }

    void MovePlayer()// ABSTRACTION
    {
        float horizontalInPut = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");   
        playerRb.AddForce(Vector3.right * speed * horizontalInPut); 
        playerRb.AddForce(Vector3.forward * speed * verticalInput); 

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            isOnGround = false;            
        }         
    }

    void ConstraintPlayer()// ABSTRACTION
    {
        if(transform.position.z < lowerbound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,lowerbound);
        }

        if(transform.position.z > upperBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,upperBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.transform.parent.gameObject);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Bullets"))
        {
            Destroy(other.transform.parent.gameObject);
            Destroy(other.gameObject);
            numberOfBullets = 5;
        }              
    }

    void FireBullets()
    {   
        Instantiate(bulletPrefab,transform.position,bulletPrefab.transform.rotation);
    }
   
}
