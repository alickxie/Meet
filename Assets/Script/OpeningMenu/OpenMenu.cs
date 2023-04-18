using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public Animator open;

    public void OpenNextScene()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        open.SetTrigger("next");
        yield return new WaitForSeconds(1.5f);
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
