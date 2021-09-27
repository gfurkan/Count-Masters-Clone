using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject parentPlayer;
    private Vector3 distance;

    private void Start()
    {
        distance = transform.position - parentPlayer.transform.position;
    }
    void LateUpdate()
    {
        transform.position = parentPlayer.transform.position + distance;
    }
}
