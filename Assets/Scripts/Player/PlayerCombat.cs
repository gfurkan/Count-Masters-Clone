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
            other.transform.GetComponent<Collider>().enabled = false;

            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
        if (other.gameObject.tag == "KillZone")
        {
            Destroy(transform.gameObject);
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
