using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickNext : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    bool singleton = false;

    public AudioSource ClickSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (singleton == false)
        {
            singleton = true;
            animator.SetTrigger("clicked");
            StartCoroutine(Next());
        }
    }

    IEnumerator Next()
    {
        ClickSound.Play();
        yield return new WaitForSeconds(3.0f);
        //Load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
