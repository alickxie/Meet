using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkStages : MonoBehaviour
{
    Animator anim;

    public int NextSceneNum;

    public List<GameObject> answers1;
    public List<GameObject> answers2;

    // get the ui image
    public Image toImage;
    public Image maoImage;

    public int count = 0;
    bool wait;
    bool singleWait;

    public AudioSource Totalk;
    public AudioSource MaoTalk;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wait == true && singleWait == false)
        {
            StartCoroutine(Wait());
            singleWait = true;
        }
    }

    public void NextSelection()
    {
        if (wait == false)
        {
            count++;
            
            // if count is odd
            if (count % 2 == 1)
            {
                StartCoroutine(TalkWait());
                wait = true;
            }

            // set answer1 and answer2 index [count] to true, and the rest to false
            for (int i = 0; i < answers1.Count; i++)
            {
                if (i == count)
                {
                    answers1[i].SetActive(true);
                    answers2[i].SetActive(true);
                }
                else
                {
                    answers1[i].SetActive(false);
                    answers2[i].SetActive(false);
                }
            }
        }
    }

    IEnumerator Wait()
    {
        Debug.Log("Start 5s wait");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("End 5s wait");
        wait = false;
        singleWait = false;
        if (NextSceneNum == count)
        {
            // build index ++
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        NextSelection();
    }

    IEnumerator TalkWait()
    {
        anim.SetTrigger("toTalk");
        Totalk.Play();
        yield return new WaitForSeconds(1.2f);
        toImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
        maoImage.color = new Color(1, 1, 1, 1);
        anim.SetTrigger("maoTalk");
        MaoTalk.Play();
        yield return new WaitForSeconds(1.2f);
        toImage.color = new Color(1, 1, 1, 1);
        maoImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
        anim.SetTrigger("back");
    }
}
