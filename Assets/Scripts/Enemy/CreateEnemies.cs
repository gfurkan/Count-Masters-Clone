using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class CreateEnemies : MonoBehaviour
{
    [SerializeField]
    private int groupSize;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private TextMeshProUGUI groupSizeText;
    [SerializeField]
    private Image groupSizeImage;

    private static EnemyCharacterPool enemyCharacterPool;
    void Start()
    {
        enemyCharacterPool = EnemyCharacterPool.Instance;
        for(int i = 0; i < groupSize; i++)
        {
           /* GameObject character = enemyCharacterPool.enemyPool.Dequeue();
            character.transform.position= new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y, transform.position.z + Random.Range(-1.25f, -0.75f));
            character.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            character.transform.parent = transform; */ // ******* Tried to pool enemies but failed :(
            Instantiate(enemyPrefab, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y, transform.position.z + Random.Range(-1.25f, -0.75f)), Quaternion.Euler(0,180,0), transform);
        }
    }
    private void Update()
    {
        groupSizeText.text = (transform.childCount - 1).ToString();
        if(transform.childCount - 1==0)
        {
            groupSizeImage.GetComponent<CanvasGroup>().DOFade(0, 0.25f);
        }
    }
}
