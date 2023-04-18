using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_pieces : MonoBehaviour
{
    public List<GameObject> pieces;
    public GameObject hold_place;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomizeWait());
        StartCoroutine(Turnoff());
    }

    IEnumerator randomizeWait()
    {
        yield return new WaitForSeconds(0.01f);
        Randomize();
    }

    IEnumerator Turnoff()
    {
        yield return new WaitForSeconds(0.01f);
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(false);
        }
        pieces[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // call OpenNextPiece() when previous piece is in the right position
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].GetComponent<pieces>().isRight == true)
            {
                if (i + 1 < pieces.Count)
                {
                    OpenNextPiece();
                }
            }
        }
    }

    // randomize the pieces index in the list, set the position of the pieces
    void Randomize()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            GameObject temp = pieces[i];
            int randomIndex = Random.Range(i, pieces.Count);
            pieces[i] = pieces[randomIndex];
            pieces[randomIndex] = temp;
        }

        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].transform.position = hold_place.transform.position;
        }
    }


    // only open one piece at a time, until piece isRight is true, open the next piece
    public void OpenNextPiece()
    {
        foreach (GameObject piece in pieces)
        {
            if (piece.GetComponent<pieces>().isRight == false)
            {
                piece.SetActive(true);
                break;
            }
        }
    }
}
