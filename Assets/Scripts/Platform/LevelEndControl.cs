using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndControl : MonoBehaviour
{
    private bool lineUpCharacters = false;
    private GameObject players;

    private void Update()
    {
        if (lineUpCharacters)
        {
            LineUpCharacters();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ActivePlayers")
        {
            players = other.gameObject;
            other.GetComponent<PlayerCharactersMovement>().enabled = false;
            lineUpCharacters = true;
            other.GetComponent<Collider>().enabled = false;
        }
    }

    void LineUpCharacters()
    {

    }
}
