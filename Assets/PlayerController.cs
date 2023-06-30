using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1f;
    public KeyCode KeyUp = KeyCode.W;
    public KeyCode KeyDown = KeyCode.S;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyUp)&&transform.position.y < 4f)
        {
            transform.position += Vector3.up * Time.deltaTime * Speed;
        }else if (Input.GetKey(KeyDown)&&transform.position.y > -4f)
        {
            transform.position += Vector3.down * Time.deltaTime * Speed;
        }
    }
}
