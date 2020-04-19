using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;

    public GameObject Shooter;

    Vector3 direction;
    float angle;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        else
        {
            direction = player.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = 270 + (angle);

        }




    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<Health>().HelathReduce();

        }

        if (other.CompareTag("Wall"))
        {

            DestroyProjectile();

        }

        if (other.CompareTag("BreakableWall"))
        {

            DestroyProjectile();

        }

        if (other.tag == "BreakableWall")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Health>().HelathReduce();


        }


    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }



}
