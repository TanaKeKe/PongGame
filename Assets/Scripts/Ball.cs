using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class Ball : MonoBehaviour
{

    private Rigidbody2D _rb;
    private bool _isTouchEnemy;
    private bool _isTouchPlayer;
    private float _xPos;
    private float _xPosEnemy;
    private float _xPosPlayer;
    private Vector2 _direction;
    private int _pointPlayer;
    private int _pointEnemy;
    
    [SerializeField] private TMPro.TextMeshProUGUI scorePlayer;
    [SerializeField] private TMPro.TextMeshProUGUI scoreEnemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject ball;
    private void Awake()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _pointPlayer = 0;
        _pointEnemy = 0;
        scoreEnemy.text = _pointEnemy.ToString();
        scorePlayer.text = _pointPlayer.ToString();
        
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

    private void Update()
    {
        _xPos = this.transform.position.x;
        _xPosEnemy = enemy.transform.position.x;
        _xPosPlayer = player.transform.position.x;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("ScorePlayer"))
        {
            ++_pointPlayer;
            scorePlayer.text = _pointPlayer.ToString();
            ResetBall();
        }

        if (collision.gameObject.CompareTag("ScoreEnemy"))
        {
            ++_pointEnemy;
            scoreEnemy.text = _pointEnemy.ToString();
            ResetBall();
        }

    }


    private void BounceWall()
    {
        if (_isTouchPlayer)
        {
            if (_direction.y < 0) _direction.y *= -1;
            _rb.velocity = _direction;
        }
        else if(_isTouchEnemy)
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
    
    private void ResetBall()
    {
        StartCoroutine(DelayAction());
    }

    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(1);
        this.transform.position = Vector3.zero;
    }
    
}
