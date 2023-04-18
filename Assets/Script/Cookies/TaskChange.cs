using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskChange : MonoBehaviour
{
    public GameObject phases;
    public GameObject phases1;
    public GameObject phases2;
    public GameObject phases3;

    public GameObject MakingCookie;
    public GameObject CookingCookie;
    public GameObject DecoratingCookie;
    public GameObject FinishCookie;
    public GameObject CarryCookie;

    public GameObject bags;
    public GameObject stickers;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        phases2.GetComponent<CanvasGroup>().alpha = 0;
        phases3.GetComponent<CanvasGroup>().alpha = 0;
        phases2.SetActive(false);
        phases3.SetActive(false);
        stickers.GetComponent<CanvasGroup>().alpha = 0;
        stickers.SetActive(false);
        CookingCookie.SetActive(false);
        DecoratingCookie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if count is 1, then slowly fade out the first phase and fade in the second phase
        if (count == 1)
        {
            phases1.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (phases1.GetComponent<CanvasGroup>().alpha <= 0)
            {
                phases1.SetActive(false);
            }
            phases2.SetActive(true);
            phases2.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        }
        if (count == 2)
        {
            phases2.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (phases2.GetComponent<CanvasGroup>().alpha <= 0)
            {
                phases2.SetActive(false);
            }
            phases3.SetActive(true);
            phases3.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        }
        if (count == 3)
        {
            MakingCookie.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (MakingCookie.GetComponent<CanvasGroup>().alpha <= 0)
            {
                MakingCookie.SetActive(false);
                CookingCookie.SetActive(true);
                CookingCookie.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            }
        }
        if (count == 4)
        {
            CookingCookie.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (CookingCookie.GetComponent<CanvasGroup>().alpha <= 0)
            {
                CookingCookie.SetActive(false);
                DecoratingCookie.SetActive(true);
                DecoratingCookie.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            }
        }
        if (count == 5)
        {
            bags.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (bags.GetComponent<CanvasGroup>().alpha <= 0)
            {
                bags.SetActive(false);
                stickers.SetActive(true);
                stickers.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            }
        }
        if (count == 6)
        {
            DecoratingCookie.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (DecoratingCookie.GetComponent<CanvasGroup>().alpha <= 0)
            {
                DecoratingCookie.SetActive(false);
                FinishCookie.SetActive(true);
                FinishCookie.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            }
        }
        if (count == 7)
        {
            FinishCookie.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (FinishCookie.GetComponent<CanvasGroup>().alpha <= 0)
            {
                FinishCookie.SetActive(false);
                CarryCookie.SetActive(true);
                CarryCookie.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            }
        }
        if (count == 8)
        {
            CarryCookie.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (CarryCookie.GetComponent<CanvasGroup>().alpha <= 0)
            {
                CarryCookie.SetActive(false);
                // Load the next scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void NextPanel()
    {
        count++;
    }

    // when current task is completed, shift phases rect transform to left by -550 smoothly
    public void ShiftLeft()
    {
        StartCoroutine(ShiftLeftCoroutine());
        count++;
    }

    IEnumerator ShiftLeftCoroutine()
    {
        float time = 0;
        float duration = 1f;
        float start = phases.GetComponent<RectTransform>().anchoredPosition.x;
        float end = start - 550;

        while (time < duration)
        {
            time += Time.deltaTime;
            float x = Mathf.Lerp(start, end, time / duration);
            phases.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
            yield return null;
        }
    }
}
