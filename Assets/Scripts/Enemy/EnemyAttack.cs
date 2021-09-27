using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyAttack : MonoBehaviour
{
    private bool playerDied = false;
    private GameObject group;

    private void Update()
    {
        if (group.transform.childCount-1 == 0)
        {
            playerDied = true;
        }

        if (!playerDied)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                NavMeshAgent agent = transform.GetChild(i).GetComponent<NavMeshAgent>();
                Animator animator = transform.GetChild(i).GetComponent<Animator>();

                animator.SetBool("Run", true);
                agent.SetDestination(transform.position);
            }
        }
        if (playerDied)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                NavMeshAgent agent = transform.GetChild(i).GetComponent<NavMeshAgent>();
                Animator animator = transform.GetChild(i).GetComponent<Animator>();

                animator.SetBool("Run", false);
                animator.SetBool("Idle", true);
            }
        }
    }
   public void GoToPlayerGroup(GameObject group,float speed,Vector3 groupPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, groupPosition, speed * Time.deltaTime);
        this.group = group;
    }
}
