using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingCookies : MonoBehaviour
{
    [SerializeField] GameObject rabitCookies;
    [SerializeField] GameObject starCookies;
    [SerializeField] GameObject catCookies;
    [SerializeField] Sprite CookiesCondition1;
    [SerializeField] Sprite CookiesCondition2;
    [SerializeField] Sprite CookiesCondition3;
    [SerializeField] ProgressSlider progressSlider;

    bool singloton = false;

    public GameObject ovenButton;
    public GameObject ovenButtonDown;
    public GameObject proceedButton;

    void Start()
    {
        proceedButton.SetActive(false);
    }

    void Update()
    {
        if (0.7f < progressSlider.GetProgress() && progressSlider.GetProgress() < 0.8f)
        {
            if (!singloton)
            {
                singloton = true;
                StartCoroutine(changeButton());
            }
            PlayerPrefs.SetInt("cookieConditions", 0);
            rabitCookies.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            starCookies.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            catCookies.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (0.8f < progressSlider.GetProgress() && progressSlider.GetProgress() < 0.9f)
        {
            PlayerPrefs.SetInt("cookieConditions", 1);
            rabitCookies.GetComponent<Image>().sprite = CookiesCondition1;
            starCookies.GetComponent<Image>().sprite = CookiesCondition2;
            catCookies.GetComponent<Image>().sprite = CookiesCondition3;
        }
    }

    IEnumerator changeButton()
    {   // slowly turn ovenButton canvasGroup alpha to 0
        while (ovenButton.GetComponent<CanvasGroup>().alpha > 0)
        {
            ovenButton.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 2;
            ovenButtonDown.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            yield return null;
        }
        ovenButton.SetActive(false);
        ovenButtonDown.SetActive(false);

        yield return new WaitForSeconds(0.3f);

        proceedButton.SetActive(true);
        while (proceedButton.GetComponent<CanvasGroup>().alpha < 1)
        {
            proceedButton.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            yield return null;
        }
    }


}
