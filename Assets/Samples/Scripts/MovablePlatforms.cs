using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;          
    public float moveDistance = 3f;   
    private float initialPosition;             
    private bool movingRight = true;  

    void Start()
    {
        initialPosition = transform.position.x; // Record initial position
    }

    void Update()
    {
        // Move platform left/right
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > initialPosition + moveDistance) 
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < initialPosition)
                movingRight = true;
        }
    }
}
