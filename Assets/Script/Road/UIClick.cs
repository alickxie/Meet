using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIClick : MonoBehaviour, IPointerClickHandler
{
    public SquareMove squareMove;
    public RoadOn roadOn;
    public PlayerForward playerForward;

    public void OnPointerClick(PointerEventData eventData)
    {
        squareMove.Stop();
        roadOn.NextRoad();

        if (roadOn.count == roadOn.roadListLength + 1)
        {
            playerForward.move();
        }
    }
}
