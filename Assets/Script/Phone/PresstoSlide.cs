using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PresstoSlide : MonoBehaviour
{
    int count = 0;
    public List<DragtoSlideNew> slots;
    public List<newSlots> sloted;
    public List<GameObject> slotsImage;
    public GameObject button;
    public Animator scene1;

    public GameObject rabbit;
    public GameObject backPanel2;

    // Sprite for the buttons
    public Sprite cantCall;
    public Sprite canCall;
    // Sprite for rabbit
    public Sprite rabbit2;

    bool nextphase = false;
    bool singleTon = true;

    public StartFade startFade;

    public List<AudioSource> DialNum;
    public AudioSource WrongNum;

    public Animator buttonPop;

    void Start()
    {
        // button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveDownAmount();
        CheckSloted();
    }

    public void MoveDownAmount()
    {
        if (count == 1 && transform.position.y > 1.57f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
        }
        if (count == 2 && transform.position.y > 0.73f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
        }
        if (count == 3 && transform.position.y > 0.03f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
        }
        if (count == 4 && transform.position.y > -0.52f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
        }
        if (count == 5 && transform.position.y > -1.172f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
            if (singleTon)
            {
                singleTon = false;
                StartCoroutine(Wait());
            }
        }

        if (count != 0)
        {
            if (backPanel2.GetComponent<Image>().color.a < 1)
            {
                backPanel2.GetComponent<Image>().color = new Color(backPanel2.GetComponent<Image>().color.r, backPanel2.GetComponent<Image>().color.g, backPanel2.GetComponent<Image>().color.b, backPanel2.GetComponent<Image>().color.a + Time.deltaTime);
            }

            if (rabbit.transform.position.x < 0.747f)
            {
                rabbit.transform.position = new Vector3(rabbit.transform.position.x + Time.deltaTime, rabbit.transform.position.y, rabbit.transform.position.z);
            }
            // else
            // {
            //     if (rabbit.GetComponent<SpriteRenderer>().color.a > 0 && !nextphase)
            //     {
            //         rabbit.GetComponent<SpriteRenderer>().color = new Color(rabbit.GetComponent<SpriteRenderer>().color.r, rabbit.GetComponent<SpriteRenderer>().color.g, rabbit.GetComponent<SpriteRenderer>().color.b, rabbit.GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
            //         if (rabbit.GetComponent<SpriteRenderer>().color.a < 0)
            //         {
            //             nextphase = true;
            //         }
            //     }

            //     if (rabbit.GetComponent<SpriteRenderer>().color.a < 1 && nextphase)
            //     {
            //         rabbit.GetComponent<SpriteRenderer>().sprite = rabbit2;
            //         rabbit.GetComponent<SpriteRenderer>().color = new Color(rabbit.GetComponent<SpriteRenderer>().color.r, rabbit.GetComponent<SpriteRenderer>().color.g, rabbit.GetComponent<SpriteRenderer>().color.b, rabbit.GetComponent<SpriteRenderer>().color.a + Time.deltaTime);
            //     }
            // }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        startFade.FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void allSlotRaycastOff()
    {
        foreach (newSlots slot in sloted)
        {
            slot.rayCast.raycastTarget = false;
        }
    }

    public void allSlotRaycastOn()
    {
        foreach (newSlots slot in sloted)
        {
            slot.rayCast.raycastTarget = true;
        }
    }

    public void CheckSlots()
    {
        if (button.GetComponent<Image>().sprite == canCall)
        {
            int innerCount = 0;
            foreach (DragtoSlideNew slot in slots)
            {
                if (slot.isSnapped)
                {
                    innerCount++;
                }

                if (!slot.isSnapped)
                {
                    slot.retrive = true;
                }
            }

            foreach (GameObject slot in slotsImage)
            {
                if (!slot.GetComponent<DragtoSlideNew>().isSnapped)
                {
                    slot.GetComponent<Image>().raycastTarget = true;
                }
            }

            foreach (newSlots slot in sloted)
            {
                if (!slot.turlyFilled)
                {
                    slot.isSlotsFilled = false;
                }
            }

            if (innerCount == 1)
            {
                count = 1;
            }
            if (innerCount == 2)
            {
                count = 2;
            }
            if (innerCount == 3)
            {
                count = 3;
            }
            if (innerCount == 4)
            {
                count = 4;
            }
            if (innerCount == 5)
            {
                count = 5;
                // button.SetActive(false);
                scene1.SetTrigger("startFade");
            }

            StartCoroutine(NumSound());
        }
    }

    IEnumerator NumSound()
    {
        int innerCount = 0;
        foreach (DragtoSlideNew slot in slots)
        {
            if (slot.isSnapped)
            {
                DialNum[innerCount].Play();
                yield return new WaitForSeconds(0.4f);
                innerCount++;
            }

            if (!slot.isSnapped)
            {
                WrongNum.Play();
                yield return new WaitForSeconds(0.4f);
            }
        }
    }

    public void CheckSloted()
    {
        int innerCount = 0;
        foreach (newSlots slote in sloted)
        {
            if (slote.isSlotsFilled)
            {
                innerCount++;
            }
        }

        if (innerCount == 5)
        {
            // Debug.Log("All slots are filled");
            buttonPop.SetBool("Popin", true);
            button.GetComponent<Image>().sprite = canCall;
        }
        else
        {
            // Debug.Log("Not all slots are filled");
            button.GetComponent<Image>().sprite = cantCall;
        }
    }
}
