using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float initialVelocity = 4;
    private Rigidbody2D ballRb;
    [SerializeField] private float velocityMultiplier = 1.1f;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier;
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("goal1"))
        {
            GameManager.Intance.Paddle1Scored();
            GameManager.Intance.Restart();
            Launch();
        }
        else
        {
            GameManager.Intance.Paddle2Scored();
            GameManager.Intance.Restart();
            Launch();
        }
    }
}
