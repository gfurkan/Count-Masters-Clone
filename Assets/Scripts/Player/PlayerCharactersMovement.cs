using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class PlayerCharactersMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterProperties playerCharacterProperties;
    [SerializeField]
    private float fightMovementSpeed = 0;
    [SerializeField]
    private TextMeshProUGUI groupSizeText;
    [SerializeField]
    private Image groupSizeImage;

    private bool _disableDraggingLeft = false, _disableDraggingRight = false, startRunning = false, fightBegin = false;

    public bool disableDraggingLeft
    {
        get
        {
            return _disableDraggingLeft;
        }
        set
        {
            _disableDraggingLeft = value;
        }
    }
    public bool disableDraggingRight
    {
        get
        {
            return _disableDraggingRight;
        }
        set
        {
            _disableDraggingRight = value;
        }
    }

    private GameObject group;
    private Vector3 groupPosition;

    InputManager inputManager;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;

    void Start()
    {
        inputManager = InputManager.Instance;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        StickingTogether();
        GroupSizeTextControls();

        if (inputManager.clicked)
        {
            startRunning = true;
        }
        if (startRunning)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                animator = transform.GetChild(i).GetComponent<Animator>();
                animator.SetBool("Run", true);
            }
            if (!fightBegin)
            {
                Movement();
            }

        }
        if (fightBegin)
        {
            GoToEnemiesLocation(group,groupPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyGroup")
        {
            other.transform.GetComponent<Collider>().enabled = false;
            group = other.gameObject;
            groupPosition = other.transform.position;

            group.GetComponent<EnemyAttack>().enabled = true;
            group.GetComponent<EnemyAttack>().GoToPlayerGroup(transform.gameObject,fightMovementSpeed,transform.position);

            fightBegin = true;
        }
    }
    void Movement()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, playerCharacterProperties.zAxisSpeed);
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
    void GoToEnemiesLocation(GameObject group,Vector3 groupPosition)
    {
        rb.velocity = Vector3.zero;
        transform.position = Vector3.MoveTowards(transform.position, groupPosition, fightMovementSpeed * Time.deltaTime);
      
        if (group.transform.childCount-1 == 0)
        {
            group.SetActive(false);
            fightBegin = false;
        }
    }
    void StickingTogether()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            agent = transform.GetChild(i).GetComponent<NavMeshAgent>();
            agent.SetDestination(transform.position);
        }

    }
    void GroupSizeTextControls()
    {
        groupSizeText.text = (transform.childCount - 1).ToString();
        if (transform.childCount - 1 == 0)
        {
            groupSizeImage.GetComponent<CanvasGroup>().DOFade(0, 0.25f);
        }
    }
}
