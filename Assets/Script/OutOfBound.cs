using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        screenBounds = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(screenBounds);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            // The GameObject is out of screen space
            transform.position = new Vector3(Random.Range(0, 1), -2.6f, 0);
        }
    }
}
