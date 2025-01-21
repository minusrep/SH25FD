using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root.Game
{
    public class ZombieSpawner : MonoBehaviour
    {
        private List<Transform> _spawnPoints;

        private float _currentTimer;

        [SerializeField] private List<GameObject> _zombiePrefabs;

        [Space] 
        
        [SerializeField] private float _spawnInterval;

        [SerializeField] private float _spawnDistance;
        
        [SerializeField] private int _maxZombies;

        [SerializeField] private Transform _player;

        [SerializeField] private Transform _parent;

        private void Awake()
        {
            _spawnPoints = new List<Transform>();

            _parent = new GameObject(this.name).transform;
            
            for (int i = 0; i < transform.childCount; i++)
                _spawnPoints.Add(transform.GetChild(i));
        }

        private void Update()
        {
            if (_currentTimer > 0f)
            {
                _currentTimer -= Time.deltaTime;
                
                return;
            }

            _currentTimer = _spawnInterval;
            
            CreateOne();
        }

        private GameObject CreateOne()
        {
            var prefab = _zombiePrefabs[Random.Range(0, _zombiePrefabs.Count)];
            
            var created = Instantiate(prefab, GetSpawnPoint(), Quaternion.identity, _parent);

            return created;
        }

        private Vector3 GetSpawnPoint()
        {
            var readyPoints  = _spawnPoints.Where(a 
                => Vector3.Distance(a.position, _player.position) >= _spawnDistance).ToArray();
            
            return readyPoints[Random.Range(0, readyPoints.Length)].position;
        }
    }
}