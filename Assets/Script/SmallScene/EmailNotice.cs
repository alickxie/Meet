using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmailNotice : MonoBehaviour
{

    public GameObject emailImage;
    public GameObject emailButton;

    public string sceneName;

    public StartFade startFade;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        audioSource = GameObject.Find("MsgPopUp").GetComponent<AudioSource>();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        emailImage.SetActive(true);
        emailButton.SetActive(true);
        audioSource.Play();
        yield return new WaitForSeconds(1);
        emailImage.GetComponent<Animator>().SetTrigger("Next");
    }

    public void NextScene()
    {
        StartCoroutine(NextSceneWait());
    }

    IEnumerator NextSceneWait()
    {
        startFade.FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
