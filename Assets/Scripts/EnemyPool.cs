using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPool : MonoBehaviour
{
    [FormerlySerializedAs("_cubePrefab")] [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _placeForSpawnedObj; // for spawn prefab in sep folder

    private readonly int _size = 7;
    private readonly Queue<GameObject> _pool = new Queue<GameObject>();
    private int _spawnedCount = 0;

    public event Action<int> OnSpawnedCountChanged;

    private void Start()
    {
        for (int i = 0; i < _size; i++)
        {
            GameObject cube = Instantiate(_enemyPrefab, _placeForSpawnedObj.transform);
            cube.gameObject.SetActive(false);
            _pool.Enqueue(cube);
        }
    }

    public GameObject TakeEnemy()
    {
        if (_pool.Count > 0)
        {
            GameObject cube = _pool.Dequeue();
            cube.SetActive(true);

            _spawnedCount++;

            UpdateSpawnedCount();

            return cube;
        }
        else
        {
            GameObject cube = Instantiate(_enemyPrefab, _placeForSpawnedObj.transform);

            return cube;
        }
    }

    public void ReturnEnemy(GameObject cube)
    {
        cube.SetActive(false);
        _pool.Enqueue(cube);
    }

    private void UpdateSpawnedCount()
    {
        OnSpawnedCountChanged?.Invoke(_spawnedCount);
    }
}