using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject aim;
    public TextMeshProUGUI text;
    public GameObject resultPanel;
    public bool clickable = true;

    void Start()
    {
        resultPanel.SetActive(false);
    }

    public void moveForward()
    {
        transform.position = aim.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "square")
        {
            Debug.Log("Entered");
            transform.parent = other.transform;
        }

        if (other.gameObject.tag == "goal")
        {
            resultPanel.SetActive(true);
            text.SetText("You Win!");
            Time.timeScale = 0;
            clickable = false;
        }

        if (other.gameObject.tag == "deadzone")
        {
            resultPanel.SetActive(true);
            text.SetText("You Lose!");
            Time.timeScale = 0;
            clickable = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "square")
        {
            Debug.Log("Exit");
            transform.parent = null;
        }
    }

}
