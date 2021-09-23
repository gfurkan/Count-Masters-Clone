using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cloner
{
    public class MultiplyCloner : MonoBehaviour
    {
        [SerializeField]
        private GameObject besideCloner;
        [SerializeField]
        private int clonerValue;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerCharacterPool playerCharacterPool = PlayerCharacterPool.Instance;
                var pool = playerCharacterPool.playerPool;
                GameObject firstPlayerCharacter = other.transform.parent.transform.GetChild(0).gameObject;

                Destroy(besideCloner.GetComponent<Collider>());

                int cloneCount = (clonerValue - 1) * other.transform.parent.transform.childCount;
                for (int i = 0; i < clonerValue; i++)
                {
                    if (pool.Count != 0)
                    {
                        GameObject character = pool.Dequeue();
                        character.transform.position = new Vector3(firstPlayerCharacter.transform.position.x + Random.Range(-0.25f, 0.25f), firstPlayerCharacter.transform.position.y, firstPlayerCharacter.transform.position.z + Random.Range(-0.25f, 0.25f));
                        character.GetComponent<Rigidbody>().useGravity = true;
                        character.transform.parent = other.transform.parent;
                    }
                }

                Destroy(transform.GetComponent<Collider>());
            }
        }
    }

}
