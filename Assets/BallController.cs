using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{ 
       public Rigidbody2D rb2D;
    public float speed = 1f;
    public Vector2 vel;
    public bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && gameStarted == false)
            SendBallToRandomDirection();
    }
    private void SendBallToRandomDirection()
    {
        rb2D.velocity = GenerateRandomVector2Without0(true) * speed;
        vel = rb2D.velocity;
    }

    private Vector2 GenerateRandomVector2Without0(bool shouldReturnNormalized)
    {
        Vector2 newVelocity = new Vector2();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        newVelocity.x = shouldGoRight ? Random.Range(.7f, .3f) : Random.Range(-.7f, -.3f);
        newVelocity.y = shouldGoRight ? Random.Range(.7f, .3f) : Random.Range(-.7f, -.3f);

        return shouldReturnNormalized ? newVelocity.normalized : newVelocity;
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        rb2D.velocity = Vector2.Reflect(vel, collision.contacts[0].normal);
        vel=rb2D.velocity;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (transform.position.x < 0)
            print("Right player +1");
        if (transform.position.x > 0)
            print("Left player +1");

        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        gameStarted = false;
       

      
    }
}
