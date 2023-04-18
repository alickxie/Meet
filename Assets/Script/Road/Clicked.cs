using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicked : MonoBehaviour
{
    public GameObject player;

    void OnMouseDown()
    {
        if (player.GetComponent<PlayerMovement>().clickable)
        {
            player.GetComponent<PlayerMovement>().moveForward();
        }
    }

    public void Retry()
    {
        // reload currrent scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
