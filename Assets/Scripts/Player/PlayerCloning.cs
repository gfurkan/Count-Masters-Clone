using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloning : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab, besideCloner;
    [SerializeField]
    private int clonerValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(besideCloner.GetComponent<Collider>());

            if (transform.tag == "PlusCloner")
            {
                ClonePlayer(clonerValue, other.gameObject);
            }
            if (transform.tag == "MultiplyCloner")
            {
                int cloneCount = (clonerValue - 1) * other.transform.parent.transform.childCount;
                ClonePlayer(cloneCount, other.gameObject);
            }

            Destroy(transform.GetComponent<Collider>());
        }
    }
    void ClonePlayer(int cloneCount,GameObject colliderObject)
    {
        for (int i = 0; i < cloneCount; i++)
        {
            Instantiate(playerPrefab, new Vector3(colliderObject.transform.position.x + Random.Range(-0.5f, 0.5f), colliderObject.transform.position.y, colliderObject.transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.identity,colliderObject.transform.parent);
        }
    }
}
