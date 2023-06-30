using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rigbody2D;
    private bool gameStarted;

    private float ballSpeed = 7.3f;
    private float newSpeed = 1.003f;

    private Vector2 velocity;

    public ScoreManager scoreManager;
    
    void Start()
    {
        rigbody2D = GetComponent<Rigidbody2D>();
        BallStartVelocity();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)&& (gameStarted == false))
        {
            BallStartVelocity();
        }
    }

    private Vector2 StartVector(bool isNormalized)
    {
        Vector2 newVelocity = new Vector2();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        newVelocity.x = shouldGoRight ? Random.Range(.8f, .3f) : Random.Range(-.8f,-.3f);
        newVelocity.y = shouldGoRight ? Random.Range(.8f, .3f) : Random.Range(-.8f,-.3f);
        return isNormalized ? newVelocity.normalized : newVelocity;
    }
    
    private void BallStartVelocity()
    {
        rigbody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rigbody2D.velocity = StartVector(true).normalized * ballSpeed;
        velocity = rigbody2D.velocity;
        gameStarted = true;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        rigbody2D.velocity = Vector2.Reflect(velocity, col.contacts[0].normal);
        velocity = rigbody2D.velocity * newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (transform.position.x > 0)
            scoreManager.IncrementLeftPlayerScore();
        
        if (transform.position.x < 0)
            scoreManager.IncrementRightPlayerScore();

        rigbody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        gameStarted = false;
    }
}
