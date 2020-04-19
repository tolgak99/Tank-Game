using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health = 100;
    public bool playerdead;

    AudioSource audiosrc;
    AudioClip audioclp_exp;

    void start()
    {
        audiosrc = GetComponent<AudioSource>();
        audioclp_exp = Resources.Load("Sounds/Try") as AudioClip;
    
    }

    public void HelathReduce()
    {
        if (this.tag == "Player")
            health -= 20;
        else if (this.tag == "Enemy")
            health -= 50;
        else if (this.tag == "BreakableWall")
            health -= 50;
        CheckDead();
    
    }

    public bool CheckDead()
    {
        if (this.tag == "Player" && health <= 0)
            playerdead = true;

        if (health <= 0)
        {
            
            Destroy(this.gameObject,2);
            
            return true;
        
        }
        else
            return false;
    
    }

   

}
