using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCharactersMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterProperties playerCharacterProperties;

    private static bool figtBegin = false, disableDraggingLeft = false,disableDraggingRight=false;

    InputManager inputManager;
    NavMeshAgent agent;
    Rigidbody rb;

    void Start()
    {
        inputManager = InputManager.Instance;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (!figtBegin)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, playerCharacterProperties.zAxisSpeed);
        }
        if (figtBegin)
        {
            agent.enabled = true;
        }
        if (inputManager.dragging) 
        {
            if (inputManager.directionVec.x > 0)
            {
                if (!disableDraggingRight)
                {
                    transform.position = new Vector3(transform.position.x + inputManager.directionVec.x * playerCharacterProperties.playerDragValue * Time.deltaTime, transform.position.y, transform.position.z);
                }
            }
            if (inputManager.directionVec.x < 0)
            {
                if (!disableDraggingLeft)
                {
                    transform.position = new Vector3(transform.position.x + inputManager.directionVec.x * playerCharacterProperties.playerDragValue * Time.deltaTime, transform.position.y, transform.position.z);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="RightEdge")
        {
            disableDraggingRight = true;
        }
        if (other.gameObject.tag == "LeftEdge")
        {
            disableDraggingLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        {
            if (other.gameObject.tag == "RightEdge")
            {
                disableDraggingRight = false;
            }
            if (other.gameObject.tag == "LeftEdge")
            {
                disableDraggingLeft = false;
            }
        }
    }
}
