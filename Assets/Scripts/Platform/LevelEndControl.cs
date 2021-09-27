using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndControl : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGroup;
    private void Update()
    {
        if (playerGroup.transform.childCount == 1)
        {
            playerGroup.GetComponent<PlayerCharactersMovement>().enabled = false;
            playerGroup.GetComponent<Rigidbody>().velocity = Vector3.zero;
            LevelManager.Instance.LevelFailed();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerGroup.GetComponent<PlayerCharactersMovement>().enabled = false;
            playerGroup.GetComponent<Rigidbody>().velocity = Vector3.zero;
            LevelManager.Instance.LevelCompleted();
        }
    }
}
