using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Drag_Drop : MonoBehaviour
{
    public GameObject SelectdPiece;
    int order = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform.CompareTag("puzzle"))
            {
                if (hit.transform.GetComponent<pieces>().isRight == false)
                {
                    SelectdPiece = hit.transform.gameObject;
                    SelectdPiece.GetComponent<pieces>().SelectdPiece = true;
                    SelectdPiece.GetComponent<SortingGroup>().sortingOrder = order;
                    order++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectdPiece != null)
            {
                SelectdPiece.GetComponent<pieces>().SelectdPiece = false;
                SelectdPiece = null;
            }
        }

        if (SelectdPiece != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectdPiece.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}
