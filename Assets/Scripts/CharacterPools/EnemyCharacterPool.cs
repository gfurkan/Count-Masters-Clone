using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterPool : MonoBehaviour
{
    #region Singleton
    private static EnemyCharacterPool _Instance = null;
    public static EnemyCharacterPool Instance
    {
        get
        {
            return _Instance;
        }
    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
    }
    #endregion

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int poolSize = 0;

    private Queue<GameObject> _enemyPool = new Queue<GameObject>();
    public Queue<GameObject> enemyPool
    {
        get
        {
            return _enemyPool;
        }
        set
        {
            _enemyPool = value;
        }
    }
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var player = Instantiate(enemyPrefab, new Vector3(0, 0, -25), Quaternion.identity, transform);
            _enemyPool.Enqueue(player);
        }
    }
}
