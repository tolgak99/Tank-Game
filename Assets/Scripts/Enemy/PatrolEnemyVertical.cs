using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyVertical : MonoBehaviour
{

    Rigidbody2D patrolBody2D;

    public float patrolSpeed;

    bool isWall, isPlayer;
    Transform wallCheck, playerCheck;
    const float WallCheckRadius = 0.2f, PlayerCheckRadius = 0.2f;
    public LayerMask wallLayer, playerLayer;
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
        //if (isPlayer)
          //  fire();
    }

    void Animations()
    {

        if (EnemyHealth.CheckDead())
        {
            patrolSpeed = 0;
            timeBtwShoots = 100;
            patrolBody2D.Sleep();
            EnemyCollider.isTrigger = true;
            audiosrc.volume = 0.1f;
            audiosrc.PlayOneShot(audioclp_exp);
            EnemyAnimation.SetBool("bum", true);

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {

            fire();

        }


    }

    void OnTriggerStay2D(Collider2D other)
    {

        
        if (other.tag == "Player" )
        {
            
            fire();

        }


    }

    void Move()
    {

        if (isWall)
        {
            moveRight = !moveRight;
        }

        patrolBody2D.velocity = (moveRight) ? new Vector2(0, +patrolSpeed) : new Vector2(0, -patrolSpeed);

          if (moveRight)
          {
              transform.rotation = Quaternion.Euler(Vector3.forward * 180);
          }

          else if (!moveRight)
          {
              transform.rotation = Quaternion.Euler(Vector3.forward * 0);
          }

       

    }

    void fire()
    {

        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            audiosrc.volume = 0.1f;
            audiosrc.PlayOneShot(audioclp_fire);
            timeBtwShoots = startTimeBtwShots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }

    }

}
