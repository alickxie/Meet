using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class lianliancan : MonoBehaviour
{
    public List<GameObject> webpages;
    public List<Sprite> grayIcons;

    public Sprite originialButton;
    public Sprite pressedButton;

    public GameObject cutscene;

    string currentStoredName;
    int enterCounter = 0;
    int winCounter = 0;

    GameObject button1;
    GameObject button2;

    public AudioSource Pushdown;
    public AudioSource Popup;

    public GameObject FrontParent;
    public GameObject OriginalParent;

    public void CheckifRelated(string iconName)
    {
        if (winCounter == 4 && iconName == "leaf")
        {
            // closeWebPage(iconName);
            cutscene.SetActive(true);
            StartCoroutine(NextScene());
        }

        enterCounter++;

        if (enterCounter == 1)
        {
            Pushdown.Play();

            justTouch(iconName);

            currentStoredName = iconName;
            button1 = EventSystem.current.currentSelectedGameObject;
            button1.GetComponent<Image>().sprite = pressedButton;

            button1.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition =
            new Vector2(button1.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition.x,
            button1.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition.y - 2.5f);

            button1.GetComponent<Button>().interactable = false;
        }

        if (enterCounter == 2)
        {
            button2 = EventSystem.current.currentSelectedGameObject;
            button2.GetComponent<Image>().sprite = pressedButton;
            button2.GetComponent<Button>().interactable = false;

            if (iconName == currentStoredName)
            {
                Pushdown.Play();

                closeWebPage(iconName);

                button2.GetComponent<Image>().sprite = pressedButton;

                button2.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition =
                new Vector2(button2.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition.x,
                button2.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition.y - 2.5f);

                button1.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = whichIcon(iconName);
                button2.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = whichIcon(iconName);
                button1 = null;
                button2 = null;
                enterCounter = 0;
                winCounter++;
            }
            else
            {
                Popup.Play();

                touchColse();

                button1.GetComponent<Image>().sprite = originialButton;
                button2.GetComponent<Image>().sprite = originialButton;

                button1.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition =
                new Vector2(button1.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition.x,
                button1.transform.GetChild(0).gameObject.GetComponent<Image>().rectTransform.anchoredPosition.y + 2.5f);

                button1.GetComponent<Button>().interactable = true;
                button2.GetComponent<Button>().interactable = true;
                button1 = null;
                button2 = null;
                enterCounter = 0;
            }
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(10f);
        // Load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    private Sprite whichIcon(string name)
    {
        if (name == "ma")
        {
            return grayIcons[3];
        }
        if (name == "cok")
        {
            return grayIcons[2];
        }
        if (name == "melon")
        {
            return grayIcons[1];
        }
        if (name == "flower")
        {
            return grayIcons[0];
        }
        return null;
    }

    private void justTouch(string name)
    {
        if (name == "ma")
        {
            webpages[0].GetComponent<RectTransform>().SetParent(FrontParent.GetComponent<RectTransform>());
        }
        if (name == "cok")
        {
            webpages[1].GetComponent<RectTransform>().SetParent(FrontParent.GetComponent<RectTransform>());
        }
        if (name == "melon")
        {
            webpages[2].GetComponent<RectTransform>().SetParent(FrontParent.GetComponent<RectTransform>());
        }
        if (name == "flower")
        {
            webpages[3].GetComponent<RectTransform>().SetParent(FrontParent.GetComponent<RectTransform>());
        }
        if (name == "leaf")
        {
            webpages[4].GetComponent<RectTransform>().SetParent(FrontParent.GetComponent<RectTransform>());
        }
    }

    private void touchColse()
    {
        webpages[0].GetComponent<RectTransform>().SetParent(OriginalParent.GetComponent<RectTransform>());
        webpages[1].GetComponent<RectTransform>().SetParent(OriginalParent.GetComponent<RectTransform>());
        webpages[2].GetComponent<RectTransform>().SetParent(OriginalParent.GetComponent<RectTransform>());
        webpages[3].GetComponent<RectTransform>().SetParent(OriginalParent.GetComponent<RectTransform>());
        webpages[4].GetComponent<RectTransform>().SetParent(OriginalParent.GetComponent<RectTransform>());
    }

    private void closeWebPage(string name)
    {
        if (name == "ma")
        {
            webpages[0].SetActive(false);
        }
        if (name == "cok")
        {
            webpages[1].SetActive(false);
        }
        if (name == "melon")
        {
            webpages[2].SetActive(false);
        }
        if (name == "flower")
        {
            webpages[3].SetActive(false);
        }
        if (name == "leaf")
        {
            webpages[4].SetActive(false);
        }
    }
}
