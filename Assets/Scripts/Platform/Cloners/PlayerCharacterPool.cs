using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cloner
{
    public class PlayerCharacterPool : MonoBehaviour
    {
        #region Singleton
        private static PlayerCharacterPool _Instance = null;
        public static PlayerCharacterPool Instance
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
        private GameObject playerPrefab;
        [SerializeField]
        private int poolSize = 0;

        private Queue<GameObject> _playerPool = new Queue<GameObject>();
        public Queue<GameObject> playerPool
        {
            get
            {
                return _playerPool;
            }
            set
            {
                _playerPool = value;
            }
        }
        void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                var player = Instantiate(playerPrefab, new Vector3(0, 0, -20), Quaternion.identity, transform);
                _playerPool.Enqueue(player);
            }
        }
    }

}
