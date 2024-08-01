using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if(transform.position.x + 1f >= rightWall.transform.position.x)
        {
            rb.velocity = new Vector2 (-speed, rb.velocity.y);
        }

        if(transform.position.x - 1f <= leftWall.transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

}
