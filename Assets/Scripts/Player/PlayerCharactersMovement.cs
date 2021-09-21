using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCharactersMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterProperties playerCharacterProperties;

    private NavMeshAgent agent;
    private Rigidbody rb;

    InputManager inputManager;
    bool figtBegin = false;

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
            transform.position = new Vector3(transform.position.x + inputManager.directionVec.x * playerCharacterProperties.playerDragValue * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
