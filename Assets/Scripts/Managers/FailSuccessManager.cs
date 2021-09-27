using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSuccessManager : MonoBehaviour
{
    private void Update()
    {
        if (transform.childCount == 1)
        {
            LevelManager.Instance.LevelFailed();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelFinish")
        {
            LevelManager.Instance.LevelCompleted();
        }
    }
}
