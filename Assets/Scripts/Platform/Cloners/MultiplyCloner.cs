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
        private GameObject playerPrefab;
        [SerializeField]
        private GameObject besideCloner;
        [SerializeField]
        private int clonerValue;

        private int cloneTime = 0;

        private void Start()
        {
            clonerText.text = "x" + clonerValue;
        }
        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                cloneTime++;
                clonerText.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
                Destroy(besideCloner.GetComponent<Collider>());
                Destroy(transform.GetComponent<Collider>());

                int cloneCount = (clonerValue - 1) * (other.transform.parent.childCount-1);
                if (cloneTime == 1)
                {
                    for (int i = 0; i < cloneCount; i++)
                    {
                        Instantiate(playerPrefab, new Vector3(other.transform.parent.position.x + Random.Range(-0.25f, 0.25f), other.transform.parent.position.y, other.transform.parent.position.z + Random.Range(-0.5f, -0.25f)), Quaternion.identity, other.transform.parent);
                    }
                }
            }
        }
    }

}
