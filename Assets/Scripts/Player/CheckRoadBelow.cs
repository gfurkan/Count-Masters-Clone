using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class CheckRoadBelow : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "KillZone")
            {
                transform.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
        if (other.gameObject.tag == "KillZone")
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            PlayerCharacterPool.Instance.playerPool.Enqueue(transform.gameObject);
            transform.parent = PlayerCharacterPool.Instance.transform;
            transform.position = new Vector3(0, -20, 0);
        }
        }
    }
