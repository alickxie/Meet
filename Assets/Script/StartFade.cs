using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFade : MonoBehaviour
{
    // Find the canvas group
    CanvasGroup canvasGroup;
    bool singleTon = false;
    bool fadeout = false;

    [SerializeField] bool inverse = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (!inverse)
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            canvasGroup.alpha = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inverse)
        {
            if (canvasGroup.alpha > 0 && !singleTon)
            {
                canvasGroup.alpha -= Time.deltaTime;
            }
            else
            {
                singleTon = true;
            }
        }
        else
        {
            if (canvasGroup.alpha < 1 && !singleTon)
            {
                canvasGroup.alpha += Time.deltaTime;
            }
            else
            {
                singleTon = true;
            }
        }

        if (fadeout)
        {
            if (inverse)
            {
                canvasGroup.alpha += Time.deltaTime;
            }
            else
            {
                canvasGroup.alpha -= Time.deltaTime;
            }
        }
    }

    public void FadeOut()
    {
        fadeout = true;
    }
}
