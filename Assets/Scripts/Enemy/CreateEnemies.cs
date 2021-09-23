using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    [SerializeField]
    private int groupSize;
    [SerializeField]
    private GameObject enemyPrefab;

    void Start()
    {
        for(int i = 0; i < groupSize; i++)
        {
            Instantiate(enemyPrefab, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y, transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.Euler(0,180,0), transform);
        }
    }
}
