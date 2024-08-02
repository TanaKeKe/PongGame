using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0,0);
    }

    private void Update()
    {
        if(ball != null)
        {
            if (ball.transform.position.y >= 0 && ball.transform.position.x >= -2.3f && ball.transform.position.x <= 2.3f) Move();
            else _rb.velocity = new Vector2(0, 0);
        }
    }

    private void Move()
    {
        
        if (this.transform.position.x < ball.transform.position.x) _rb.velocity = new Vector2(speed, 0);
        else if(this.transform.position.x > ball.transform.position.x) _rb.velocity = new Vector2(-speed, 0);
        else _rb.velocity = new Vector2(0, 0);
    }
}
