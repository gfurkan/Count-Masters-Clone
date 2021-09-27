using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Cloner
{
    public class PlusCloner : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI clonerText;
        [SerializeField]
        private GameObject besideCloner,playerPrefab;
        [SerializeField]
        private int clonerValue;

        private int cloneTime = 0;

        private void Start()
        {
            clonerText.text = "+" + clonerValue;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                cloneTime++;
                clonerText.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                Destroy(besideCloner.GetComponent<Collider>());

                if (cloneTime == 1)
                {
                    for (int i = 0; i < clonerValue; i++)
                    {
                        Instantiate(playerPrefab, new Vector3(other.transform.parent.transform.position.x + Random.Range(-0.25f, 0.25f), other.transform.parent.transform.position.y, other.transform.parent.transform.position.z + Random.Range(-0.5f, -0.25f)), Quaternion.identity, other.transform.parent);
                    }
                }
                Destroy(transform.GetComponent<Collider>());
            }
        }
    }
}

