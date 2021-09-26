using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            transform.GetComponent<Collider>().enabled = false;
            Destroy(other.gameObject);
            //other.transform.GetComponent<Collider>().enabled = false;
            transform.GetComponent<NavMeshAgent>().enabled = false;
            
            transform.position = new Vector3(0, 0, -20);
            transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterPool").transform;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "RightEdge")
        {
           transform.parent.GetComponent<PlayerCharactersMovement>().disableDraggingRight = true;
        }
        if (other.gameObject.tag == "LeftEdge")
        {
            transform.parent.GetComponent<PlayerCharactersMovement>().disableDraggingLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        {
            if (other.gameObject.tag == "RightEdge")
            {
                transform.parent.GetComponent<PlayerCharactersMovement>().disableDraggingRight = false;
            }
            if (other.gameObject.tag == "LeftEdge")
            {
                transform.parent.GetComponent<PlayerCharactersMovement>().disableDraggingLeft = false;
            }
        }
    }
}
