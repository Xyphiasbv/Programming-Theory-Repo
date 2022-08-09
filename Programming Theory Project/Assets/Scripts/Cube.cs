using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cube : MonoBehaviour
{
    [SerializeField]
    private float speed;// INHERITANCE same for all cubes, is also influenced by mass, see MoveObjects script.
    [SerializeField]
    protected float health;// POLYMORPHISM health is different for every size cube.
    private float currentHealth;
    public float cubeSpeed{ get; private set; }// ENCAPSULATION

    // INHERITANCE
    public Cube()
    {
        speed = 5.0f;
    }
    // INHERITANCE  

    void Awake()
    {
        cubeSpeed = speed;//ENCAPSULATION set cubeSpeed
        currentHealth = health;    
    }

    void ManageHealth(Collider other){ // ABSTRACTION
        if(other.gameObject.CompareTag("Bullet")){
            currentHealth = currentHealth -1;
        }
        
        if(currentHealth == 0)
        {
            Destroy(gameObject);    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ManageHealth(other);// ABSTRACTION
        
        if (other.transform.parent.gameObject){
            Destroy(other.transform.parent.gameObject);    
        }       
        
        Destroy(other.gameObject);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
