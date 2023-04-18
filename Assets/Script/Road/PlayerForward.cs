using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    // if true, move player up
    public bool moveUp = false;
    public GameManager gameManager;

    void Update()
    {
        if (moveUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
    }

    public void move()
    {
        moveUp = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goal"))
        {
            gameManager.WinorLose(0);
            moveUp = false;
        }

        if (other.gameObject.CompareTag("roadend"))
        {
            gameManager.WinorLose(1);
            moveUp = false;
        }
    }
}
