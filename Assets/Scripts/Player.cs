using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if(audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (position.y <= 0)
        {
            if (position.x <= 2f && position.x >= -2f) this.transform.position = new Vector2(position.x, -4f);
            else if (position.x > 2f) this.transform.position = new Vector2(2f, -4f);
            else if (position.x < -2f) this.transform.position = new Vector2(-2f, -4f);
        }
    }
}




