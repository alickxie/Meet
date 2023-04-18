using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatPopUp : MonoBehaviour
{
    public List<GameObject> maoLines;
    public List<GameObject> toLines;
    public List<GameObject> toEmojis;
    public List<GameObject> emojiButtonList;
    public List<Sprite> emojiList;
    public GameObject chatArea;

    bool StartMoveDown;
    int numLine = 0;
    bool wait;
    bool singleWait;

    [SerializeField] int lineCount = 0;

    public AudioSource PopUP;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartChat());
    }

    IEnumerator StartChat()
    {
        yield return new WaitForSeconds(1f);
        PopUP.Play();
        maoLines[0].SetActive(true);
    }

    public void NextLine(int buttonNum)
    {
        if (wait == false)
        {
            PopUP.Play();
            lineCount++;
            toEmojis[lineCount - 1].GetComponent<Image>().sprite = emojiButtonList[buttonNum - 1].GetComponent<Image>().sprite;
            emojiButtonList[buttonNum - 1].GetComponent<Image>().sprite = emojiList[lineCount + 3];
            toLines[lineCount - 1].SetActive(true);
            StartCoroutine(Chatting());
            wait = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        wait = false;
        singleWait = false;
    }

    IEnumerator Chatting()
    {
        if (lineCount > 1)
        {
            StartMoveDown = true;
            numLine++;
        }
        yield return new WaitForSeconds(2f);
        if (lineCount < 2)
        {
            PopUP.Play();
            maoLines[lineCount].SetActive(true);
        }
        else
        {
            PopUP.Play();
            maoLines[lineCount - 1].SetActive(true);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartMoveDown)
        {
            // move chat area rect transform y position up by 164 slowly
            if (chatArea.GetComponent<RectTransform>().anchoredPosition.y < 198.5f * numLine)
            {
                chatArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, chatArea.GetComponent<RectTransform>().anchoredPosition.y + 300f * Time.deltaTime);
            }
        }

        if (wait == true && singleWait == false)
        {
            StartCoroutine(Wait());
            singleWait = true;
        }

        if (lineCount > 3)
        {
            this.gameObject.GetComponent<StartFade>().FadeOut();
            StartCoroutine(NextScene());
        }
    }
}
