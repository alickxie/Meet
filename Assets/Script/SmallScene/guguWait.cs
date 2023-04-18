using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guguWait : MonoBehaviour
{
    public GameObject gugu;
    public Animator guguAnimator;

    public StartFade startFade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        gugu.SetActive(true);
        yield return new WaitForSeconds(1);
        guguAnimator.SetTrigger("Next");
        yield return new WaitForSeconds(2);
        startFade.FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
