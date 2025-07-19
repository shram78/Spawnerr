using System;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _placeForSpawnedObj; // for spawn prefab in sep folder

    private int _size = 10;
    private readonly Queue<GameObject> _pool = new Queue<GameObject>();
    private int _spawnedCount = 0; 
    private int _totalSpawned = 0;
    
    public event Action<int> OnSpawnedCountChanged;

    void Start()
    {
        for (int i = 0; i < _size; i++)
        {
            GameObject cube = Instantiate(_cubePrefab);
            cube.gameObject.SetActive(false);
            _pool.Enqueue(cube);

            cube.transform.parent = _placeForSpawnedObj.transform;
        }
    }

    public GameObject TakeCube()
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
            GameObject cube = Instantiate(_cubePrefab);

            return cube;
        }
    }

    public void ReturnCube(GameObject cube)
    {
        cube.SetActive(false);
        _pool.Enqueue(cube);
    }

    public void UpdateSpawnedCount()
    {
        OnSpawnedCountChanged?.Invoke(_spawnedCount);
    }
}
