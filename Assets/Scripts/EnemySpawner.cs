using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private CubePool _cubePool;
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
        GameObject cube = _cubePool.TakeCube();

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
        _cubePool.ReturnCube(cube);

        _activeCubes.RemoveAt(lastCube);
    }
}
