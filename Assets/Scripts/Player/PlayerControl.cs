using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

   
    public float speed=0.1f;
    public float BulletSpeed;

    Rigidbody2D body;
    public GameObject BulletPrefab;

    public Health health;

     AudioSource audiosrc;
     AudioClip audioclp_fire;
     AudioClip audioclp_exp;
     AudioClip audioclp_start;

     float delay = 2;

     Animator PlayerAnimation;

    void Start()
    {
        
        body = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();

        body.gravityScale = 0;

        audiosrc = GetComponent<AudioSource>();
        audioclp_fire = Resources.Load("Sounds/TankFire") as AudioClip;
        audioclp_exp = Resources.Load("Sounds/TankExp") as AudioClip;
        audioclp_start = Resources.Load("Sounds/Start") as AudioClip;

        audiosrc.volume = 0.1f;
        audiosrc.PlayOneShot(audioclp_start);

        PlayerAnimation = GetComponent<Animator>();
    }


    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            body.transform.Translate(new Vector3(h, v, 0) * speed, Space.World);
            body.transform.up = new Vector3(-h, -v, 0);
            BulletPrefab.transform.up = new Vector3(-h, -v, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Yes");
            Fire();

        }
        Explosive();

    }

    public void Fire()
    {

        GameObject MovingBullet = Instantiate(BulletPrefab);

        MovingBullet.GetComponent<BulletScript>().Shooter = this.gameObject;

        MovingBullet.transform.position = this.transform.position;
        MovingBullet.GetComponent<Rigidbody2D>().AddForce(-body.transform.up * BulletSpeed);

        MovingBullet.transform.position = body.transform.position;

        audiosrc.volume = 0.5f;
        audiosrc.PlayOneShot(audioclp_fire);
        


    }

    void Explosive()
    {
        if (this.gameObject.GetComponent<Health>().health<=0)
        {
            speed = 0;
            BulletSpeed = 0;
            playerCollider.isTrigger = true;
            audiosrc.volume = 0.20f;
            audiosrc.PlayOneShot(audioclp_exp);
            PlayerAnimation.SetBool("bum", true);
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                Scene scence = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scence.name);
            }
        
        }
    
    }

  


}
