using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    private Rigidbody2D _rb;
    private bool _isTouchEnemy;
    private bool _isTouchPlayer;
    private float _xPos;
    private float _xPosEnemy;
    private float _xPosPlayer;
    private Vector2 _direction;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    private void Awake()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _xPos = this.transform.position.x;
        _xPosEnemy = enemy.transform.position.x;
        _xPosPlayer = player.transform.position.x;
        _direction = new Vector2(6f, -4.5f);
        _rb.velocity = _direction;
        _isTouchEnemy = true;
        _isTouchPlayer = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {
            if (_direction.x > 0) _direction.x *= -1;
            BounceWall();
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            if (_direction.x < 0) _direction.x *= -1;
            BounceWall();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTouchEnemy = false;
            _isTouchPlayer = true;
            BouncePlayer();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _isTouchEnemy = true;
            _isTouchPlayer = false;
            BounceEnemy();
        }
    }


    private void BounceWall()
    {
        if (_isTouchPlayer)
        {
            if (_direction.y < 0) _direction.y *= -1;
            _rb.velocity = _direction;
        }
        else
        {
            if (_direction.y > 0) _direction.y *= -1;
            _rb.velocity = _direction;
        }
    }

    private void BouncePlayer()
    {
        if (_direction.y < 0) _direction.y *= -1;

        if (_xPos < _xPosPlayer)
        {
            if (_direction.x > 0) _direction.x *= -1;
        }
        else if (_xPos > _xPosPlayer)
        {
            if (_direction.x < 0) _direction.x *= -1;
        }
        else _direction.x = 0;
        _rb.velocity = _direction;
    }

    private void BounceEnemy()
    {
        if (_direction.y > 0) _direction.y *= -1;

        if (_xPos < _xPosEnemy)
        {
            if (_direction.x > 0) _direction.x *= -1;
        }
        else if (_xPos > _xPosEnemy)
        {
            if (_direction.x < 0) _direction.x *= -1;
        }
        else _direction.x = Random.Range(-1f, 1f);
        _rb.velocity = _direction;
    }
}
