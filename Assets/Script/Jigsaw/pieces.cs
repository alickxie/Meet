using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class pieces : MonoBehaviour
{
    private Vector3 rightPos;
    public bool isRight = false;
    public bool SelectdPiece = false;

    bool singleton = false;

    WinCondition winCondition;

    private Camera mainCamera;
    private Vector3 screenBounds;

    AudioSource puzzleDrop;

    // Start is called before the first frame update
    void Start()
    {
        winCondition = GameObject.Find("Winmanager").GetComponent<WinCondition>();
        rightPos = transform.position;
        transform.position = new Vector3(Random.Range(0, 1), -2.6f, 0);

        mainCamera = Camera.main;

        screenBounds = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(screenBounds);

        puzzleDrop = GameObject.Find("PuzzleDrop").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightPos) < 0.5f)
        {
            if (SelectdPiece == false)
            {
                if (isRight == false)
                {
                    puzzleDrop.Play();

                    transform.position = rightPos;
                    isRight = true;
                    if (singleton == false)
                    {
                        winCondition.Add();
                        singleton = true;
                    }
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }

        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            // The GameObject is out of screen space
            transform.position = new Vector3(Random.Range(0, 1), -2.6f, 0);
        }
    }

}
