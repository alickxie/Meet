using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arrangeComplete : MonoBehaviour
{
    public TaskChange taskChange;
    public bool taskMove = true;

    bool checking1 = true;
    public int winNum;
    [SerializeField] private int count1;

    // Get the name of the sprites
    void Start()
    {
    }

    void Update()
    {
        if (checking1)
        {
            checkArrange();
        }
    }

    public void countPlus()
    {
        count1++;
    }

    public void checkArrange()
    {
        // if the count is the same as the number of sprites, then the arrange is complete
        if (count1 == winNum)
        {
            checking1 = false;
            StartCoroutine(ChangeTask());
        }
    }

    IEnumerator ChangeTask()
    {
        yield return new WaitForSeconds(1);
        if (!taskMove)
        {
            taskChange.NextPanel();
        }

        if (taskMove)
        {
            taskChange.ShiftLeft();
        }
    }
}
