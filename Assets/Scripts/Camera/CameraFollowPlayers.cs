using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayers : MonoBehaviour
{
    private GameObject firstActivePlayerCharacter;
    private Vector3 distance;


    void LateUpdate()
    {
        if (firstActivePlayerCharacter==null)
        {
            GetDistance();
        }
        if (firstActivePlayerCharacter != null)
        {
            transform.position = firstActivePlayerCharacter.transform.position + distance;
        }

    }
    void GetDistance()
    {
        firstActivePlayerCharacter = GameObject.FindGameObjectWithTag("ActivePlayers").transform.GetChild(0).gameObject;
        distance = transform.position - firstActivePlayerCharacter.transform.position;
    }
}
