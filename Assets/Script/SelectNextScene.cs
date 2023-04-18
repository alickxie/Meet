using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectNextScene : MonoBehaviour
{
    public string nextSceneName;
    public bool simplyNext = true;

    [SerializeField] private StartFade startFade;

    public void NextScene()
    {
        Debug.Log("Next Scene");
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        startFade.FadeOut();
        yield return new WaitForSeconds(1f);
        if (simplyNext)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
