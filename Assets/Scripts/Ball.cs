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

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

        }

        if (collision.gameObject.CompareTag("Player"))
        {

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

        }

        if (collision.gameObject.CompareTag("Score"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }


}
