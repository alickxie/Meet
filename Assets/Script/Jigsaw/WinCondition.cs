using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    int winNum = 9;
    int count = 0;

    AudioSource CompletePuzzle;

    bool singleton = false;

    void Start()
    {
        CompletePuzzle = GameObject.Find("Complete").GetComponent<AudioSource>();
    }

    public void Add()
    {
        count++;
    }

    void Update()
    {
        if (count == winNum)
        {
            if (singleton == false)
            {
                CompletePuzzle.Play();
                singleton = true;
            }
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
