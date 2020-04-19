using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject Shooter;
   

    public bool isCrush;
    
    void Start()
    {

        Destroy(this.gameObject,2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player ")
        {
            if (Shooter != other.gameObject)
            { 
            
               other.gameObject.GetComponent<Health>().HelathReduce();
               Destroy(this.gameObject);
            
            }
        
        }

        if (other.tag == "Enemy")
        {
  
                other.gameObject.GetComponent<Health>().HelathReduce();
                Destroy(this.gameObject);

        }

        if(other.tag == "Wall")
            Destroy(this.gameObject);

        if (other.tag == "BreakableWall")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Health>().HelathReduce();
            
     
        }
       

    }

}
