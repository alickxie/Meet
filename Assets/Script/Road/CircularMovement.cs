using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public Transform RotationCenter;

    public float AngularSpeed;
    public float RotationRadius;

    private float posX, posY, angle = 0;

    // Update is called once per frame
    void Update()
    {
        posX = RotationCenter.position.x + Mathf.Cos(angle) * RotationRadius;
        posY = RotationCenter.position.y + Mathf.Sin(angle) * RotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += AngularSpeed * Time.deltaTime;

        if (angle >= 360)
        {
            angle = 0;
        }
    }
}
