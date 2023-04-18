using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadOn : MonoBehaviour
{
    public List<GameObject> roadList;
    public List<SquareMove> squareMoves;
    public int count = 1;
    public int roadListLength;

    // Turn on one road at a time
    void Start()
    {
        foreach (GameObject road in roadList)
        {
            road.SetActive(false);
        }
        roadList[0].SetActive(true);
        // get the length of the list
        roadListLength = roadList.Count;
    }

    // Turn on the next road
    public void NextRoad()
    {
        if (count != roadListLength + 1)
        {
            squareMoves[count - 1].Stop();
            if (count != roadListLength)
            {
                roadList[count].SetActive(true);
            }
            count++;
        }
    }

}
