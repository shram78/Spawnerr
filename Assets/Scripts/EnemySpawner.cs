using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [FormerlySerializedAs("_cubePool")] [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private float _spawnInterval;

    private readonly List<GameObject> _activeCubes = new List<GameObject>();
    private bool[] _isCellBusy;
    private float _timer;
    
    private void Start()
    {
        _isCellBusy = new bool[_spawnPoints.Length];
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            TryToKill();
        
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            FindSpawnPosition();
            _timer = 0;
        }
    }

    private void FindSpawnPosition()
    {
      int  spawnIndex = Random.Range(0, _spawnPoints.Length);

        if (_isCellBusy[spawnIndex]  == false)
        {
            Spawn(spawnIndex);
            _isCellBusy[spawnIndex] = true;
        }
    }
   

    private void Spawn(int spawnIndex)
    {
        GameObject cube = enemyPool.TakeEnemy();

        cube.transform.position = _spawnPoints[spawnIndex].transform.position;
        
        _activeCubes.Add(cube);

    }

    private void TryToKill()
    {
        int  killIndex = Random.Range(0, _spawnPoints.Length);
        if (_isCellBusy[killIndex]  == true)
        {
            ReturnCube();
            _isCellBusy[killIndex] = false;
        }
    }

    private void ReturnCube()
    {
        if (_activeCubes.Count == 0) return;

        int lastCube = _activeCubes.Count - 1;

        GameObject cube = _activeCubes[lastCube];
        enemyPool.ReturnEnemy(cube);

        _activeCubes.RemoveAt(lastCube);
    }
}
