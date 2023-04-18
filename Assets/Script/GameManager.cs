using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    bool win = false;
    bool lose = false;

    float currentTime = 0f;
    float startingTime = 30f;

    void Start()
    {
        Time.timeScale = 1;
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0 && !lose)
        {
            currentTime = 0;
            lose = true;
        }

        if (win)
        {
            victoryScreen.SetActive(true);
            // Time.timeScale = 0;
        }

        if (lose)
        {
            defeatScreen.SetActive(true);
            // Time.timeScale = 0;
        }
    }

    public void WinorLose(int x)
    {
        if (x == 0) { win = true; }
        if (x == 1) { lose = true; }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        // win = false;
        // lose = false;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
