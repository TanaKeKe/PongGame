using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private float speed;
    [SerializeField] private float buff;
    [SerializeField] private Vector2 upperRight;
    [SerializeField] private Vector2 lowerRight;
    [SerializeField] private Vector2 upperLeft;
    [SerializeField] private Vector2 lowerLeft;
    private bool checkTouchPlayer;
    private bool checkTouchEnemy;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        rb.velocity = new Vector2(speed, -speed - buff);// chỉnh random sau đang để mặc định là người chơi trước
        checkTouchPlayer = false;
        checkTouchEnemy = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            touchLeft();
            touchRight();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            checkTouchPlayer = true;
            checkTouchEnemy = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            checkTouchEnemy = true;
            checkTouchPlayer = false;
        }

        if (collision.gameObject.CompareTag("Score"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }


    private void touchRight()
    {
        if (this.transform.position.x + 1f >= rightWall.transform.position.x)
        {
            if (checkTouchEnemy)
            {
                rb.velocity = lowerRight;

            }
            else if (checkTouchPlayer)
            {
                rb.velocity = upperLeft;
            }
            else
            {
                if (this.transform.position.y >= 0)
                {
                    rb.velocity = upperLeft;
                }
                else
                {
                    rb.velocity = lowerLeft;
                }
            }
        }
    }


    private void touchLeft()
    {

        if (this.transform.position.x - 1f <= leftWall.transform.position.x)
        {
            if (checkTouchEnemy)
            {
                rb.velocity = lowerLeft;
            }
            else if (checkTouchPlayer)
            {
                rb.velocity = upperRight;
            }
            else
            {
                if (this.transform.position.y >= 0)
                {
                    rb.velocity = upperRight;
                }
                else
                {
                    rb.velocity = lowerRight;
                }
            }
        }
    }


}
