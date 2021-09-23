using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            transform.GetComponent<Collider>().enabled = false;
            other.transform.GetComponent<Collider>().enabled = false;

            transform.position = new Vector3(0, 0, -20);
            transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterPool").transform;
            other.gameObject.SetActive(false);
        }
    }
}
