using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 3f;

    private Vector2 leftPoint;
    private Vector2 rightPoint;
    private bool movingLeft = true;
    private Vector3 originalScale;

    void Start()
    {
        Vector2 startPos = transform.position;
        leftPoint = startPos - Vector2.right * patrolDistance;
        rightPoint = startPos + Vector2.right * patrolDistance;

        originalScale = transform.localScale; // store correct scale
    }

    void Update()
    {
        if (movingLeft)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPoint, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, leftPoint) < 0.05f)
            {
                movingLeft = false;
                Flip(false); // face right
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPoint, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, rightPoint) < 0.05f)
            {
                movingLeft = true;
                Flip(true); // face left
            }
        }
    }

    void Flip(bool faceLeft)
    {
        transform.localScale = new Vector3(
            faceLeft ? -Mathf.Abs(originalScale.x) : Mathf.Abs(originalScale.x),
            originalScale.y,
            originalScale.z
        );
    }
}


