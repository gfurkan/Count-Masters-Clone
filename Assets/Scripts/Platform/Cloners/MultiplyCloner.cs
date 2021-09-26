using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Cloner
{
    public class MultiplyCloner : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI clonerText;
        [SerializeField]
        private GameObject besideCloner;
        [SerializeField]
        private int clonerValue;

        private void Start()
        {
            clonerText.text = "x" + clonerValue;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                clonerText.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                PlayerCharacterPool playerCharacterPool = PlayerCharacterPool.Instance;
                var pool = playerCharacterPool.playerPool;
                GameObject firstPlayerCharacter = other.transform.parent.transform.GetChild(0).gameObject;

                Destroy(besideCloner.GetComponent<Collider>());

                int cloneCount = (clonerValue - 1) * other.transform.parent.transform.childCount;

                for (int i = 0; i < cloneCount; i++)
                {
                    if (pool.Count != 0)
                    {
                        
                        GameObject character = pool.Dequeue();
                        character.transform.position = new Vector3(firstPlayerCharacter.transform.parent.transform.position.x + Random.Range(-0.25f, 0.25f), firstPlayerCharacter.transform.parent.transform.position.y, firstPlayerCharacter.transform.parent.transform.position.z + Random.Range(-0.5f, -0.25f));
                        character.GetComponent<Rigidbody>().useGravity = true;
                        character.transform.parent = other.transform.parent;
                    }
                }

                Destroy(transform.GetComponent<Collider>());
            }
        }
    }

}
