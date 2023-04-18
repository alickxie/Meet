using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMove : MonoBehaviour
{
    public bool isLeft = true;
    public float speed = 1f;

    void FixedUpdate()
    {
        if (isLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    // Move the object left, on collider with the left wall, and move right, on collider with the right wall, and vice versa
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LeftWall")
        {
            isLeft = false;
        }
        else if (other.gameObject.name == "RightWall")
        {
            isLeft = true;
        }
    }

    public void Stop()
    {
        speed = 0;
    }
}
