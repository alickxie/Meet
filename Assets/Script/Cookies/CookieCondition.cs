using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieCondition : MonoBehaviour
{
    public List<GameObject> cookies;
    public List<Sprite> cookieCondition;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("cookieConditions") == 1)
        {
            // change each sprite of cookies to corresponding cookieCondition index sprite
            for (int i = 0; i < cookies.Count; i++)
            {
                cookies[i].GetComponent<Image>().sprite = cookieCondition[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
