using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRoad : MonoBehaviour
{
    [SerializeField]
    private GameObject road;
    [SerializeField]
    private Transform leftPos, rightPos;
    [SerializeField]
    private float movingSpeed;

    private bool moveLeft = false, moveRight = false;

    void Update()
    {
        
       if(road.transform.position.x==leftPos.position.x)
        {
            moveLeft = false;
            moveRight = true;
        }
        if (road.transform.position.x == rightPos.position.x)
        {
            moveRight = false;
            moveLeft = true;
        }
        if (moveLeft)
        {
            road.transform.position = Vector3.MoveTowards(road.transform.position,new Vector3(leftPos.position.x,road.transform.position.y,road.transform.position.z), 0.5f * Time.deltaTime * movingSpeed);
        }
        if (moveRight)
        {
            road.transform.position = Vector3.MoveTowards(road.transform.position, new Vector3(rightPos.position.x, road.transform.position.y, road.transform.position.z), 0.5f * Time.deltaTime * movingSpeed);
        }
    }

}
