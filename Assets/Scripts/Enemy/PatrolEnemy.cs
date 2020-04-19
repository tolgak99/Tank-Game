using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolEnemy : MonoBehaviour
{

    Rigidbody2D patrolBody2D;

    public float patrolSpeed;

    bool isWall,isPlayer;
    Transform wallCheck, playerCheck;
    const float WallCheckRadius = 0.2f, PlayerCheckRadius = 0.2f;
    public LayerMask wallLayer,playerLayer;
    public bool moveRight;

    public GameObject projectile;
    private float timeBtwShoots;
    public float startTimeBtwShots;

    Animator EnemyAnimation;
    Health EnemyHealth;
    Collider2D EnemyCollider;

    AudioSource audiosrc;
    AudioClip audioclp_exp;
    AudioClip audioclp_fire;
    bool playExp;
    bool playFire;


    void Start()
    {
        patrolBody2D = GetComponent<Rigidbody2D>();
        EnemyAnimation = GetComponent<Animator>();
        EnemyHealth = GetComponent<Health>();
        EnemyCollider = GetComponent<Collider2D>();

        timeBtwShoots = startTimeBtwShots;
        wallCheck = transform.Find("WallCheck");
        playerCheck = transform.Find("PlayerCheck");

        audiosrc = GetComponent<AudioSource>();
        audioclp_exp = Resources.Load("Sounds/TankExp") as AudioClip;
        audioclp_fire = Resources.Load("Sounds/TankFire") as AudioClip;
    }

    
    void Update()
    {
        isWall = Physics2D.OverlapCircle(wallCheck.position, WallCheckRadius, wallLayer);
        isPlayer = Physics2D.OverlapCircle(playerCheck.position, PlayerCheckRadius, playerLayer);

        Move();
        Animations();
        AudioPlayer();
        //if (isPlayer)
        //    fire();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (playerCheck.transform.position.y < 0 && this.transform.position.y > 0)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * -90);

        }

        if (playerCheck.transform.position.y > 0 && this.transform.position.y < 0)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * 90);

        }

        if (other.tag == "Player")
        {
            
            fire();

        }
    
    
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if(playerCheck.transform.position.y <0 && this.transform.position.y > 0)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        
        }

        if (playerCheck.transform.position.y > 0 && this.transform.position.y < 0)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * 90);

        }

        if (other.tag == "Player")
        {

            fire();

        }


    }

    void Animations()
    {

        if (EnemyHealth.CheckDead())
        {
            playExp=true;
            patrolSpeed = 0;
            timeBtwShoots = 100;
            patrolBody2D.Sleep();
            EnemyCollider.isTrigger = true;
            EnemyAnimation.SetBool("bum", true);

        }

    }

    void Move()
    {
       

        if (isWall)
        {
            moveRight = !moveRight;
        }

        patrolBody2D.velocity = (moveRight) ? new Vector2(-patrolSpeed,0 ) : new Vector2(patrolSpeed, 0);

       if (moveRight)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        }

        else if (!moveRight)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }

     

        
    }

    void fire()
    {

        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShots;
            playFire = true;
        }
        else
        {
            playFire = false; 
            timeBtwShoots -= Time.deltaTime;
        }
          
    }

    void AudioPlayer()
    {
        

     
        if (playExp && !playFire)
        {
            
            audiosrc.volume = 0.5f;
            audiosrc.PlayOneShot(audioclp_exp);

        }

        if (!playExp && playFire)
        {

            audiosrc.volume = 0.5f;
            audiosrc.PlayOneShot(audioclp_fire);

        }
    
    }

}
