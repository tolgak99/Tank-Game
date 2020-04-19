using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotEnemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShoots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    Animator EnemyAnimation;
    Health EnemyHealth;
    Collider2D EnemyCollider;
    Rigidbody2D rb;

    Vector3 direction;
    float angle;

    public bool letsmove;

    AudioSource audiosrc;
    AudioClip audioclp_exp;
    AudioClip audioclp_fire;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShoots = startTimeBtwShots;

        rb = GetComponent<Rigidbody2D>();
        EnemyAnimation = GetComponent<Animator>();
        EnemyHealth = GetComponent<Health>();
        EnemyCollider = GetComponent<Collider2D>();

        audiosrc = GetComponent<AudioSource>();
        audioclp_exp = Resources.Load("Sounds/TankExp") as AudioClip;
        audioclp_fire = Resources.Load("Sounds/TankFire") as AudioClip;

    }


    void Update()
    {

        Animations();
        if (letsmove)
        {
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            letsmove = true;
        }

    }



    void Animations()
    {

        if (EnemyHealth.CheckDead())
        {

            audiosrc.PlayOneShot(audioclp_exp);
            speed = 0;
            timeBtwShoots = 100;
            EnemyCollider.isTrigger = true;
            EnemyAnimation.SetBool("bum", true);

        }

    }

    void Move()
    {

        rb.velocity = new Vector2(0, 0);

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }



        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(projectile, transform.position = new Vector3(transform.position.x+0.4f, transform.position.y, transform.position.z), Quaternion.identity);
            audiosrc.volume = 0.1f;
            audiosrc.PlayOneShot(audioclp_fire);
            timeBtwShoots = startTimeBtwShots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }

        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = 90 + (angle);

    }



}
