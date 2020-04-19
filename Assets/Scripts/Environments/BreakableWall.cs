using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{

    BulletScript bullet;
    Animator animations;
    Health health;

    bool isRealCrush;
    bool explo;

    AudioSource audiosrc;
    AudioClip audioclp_stone;

    void Start()
    {
        bullet = GetComponent<BulletScript>();
        animations = GetComponent<Animator>();
        health = GetComponent<Health>();

        audiosrc = GetComponent<AudioSource>();
        audioclp_stone = Resources.Load("Sounds/StoneBreak") as AudioClip;
    }

    
    void Update()
    {
        
        Animations();
        Break();
        Sounds();
    }

    void Animations()
    {

        
        if (this.gameObject.GetComponent<Health>().health == 50)
        {
            
            isRealCrush = true;
        }

        if (isRealCrush)
        {

            animations.SetBool("isCrush", true);
        }
       
    }

    void Break()
    {

        if (health.CheckDead())
        {

            explo = true;
            Destroy(this.gameObject);
            
        }

    }

    void Sounds()
    {

        if (isRealCrush)
        {

            audiosrc.volume = 0.5f;
            audiosrc.PlayOneShot(audioclp_stone);
        }

        if(explo)
        {
            audiosrc.volume = 0.5f;
            audiosrc.PlayOneShot(audioclp_stone);
        
        }
    
    }

}
