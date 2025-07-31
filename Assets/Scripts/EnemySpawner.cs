using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private GameObject _enemyPrefab;

    private bool[] _isCellBusy;
    private float _timer;
    
    private void Start()
    {
        _isCellBusy = new bool[_spawnPoints.Length];
    }
    
    private void Update()
    {
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
        GameObject enemy = Instantiate(_enemyPrefab, _spawnPoints[spawnIndex].position, _spawnPoints[spawnIndex].rotation);
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.IdentIndex(spawnIndex);
    }

    public void TryToKill(int index)
    {
            _isCellBusy[index] = false;
    }
    /*private void ReturnCube()
    {
        if (_activeCubes.Count == 0) return;

       int lastCube = _activeCubes.Count - 1;

       GameObject cube = _activeCubes[lastCube];
        
        enemyPool.ReturnEnemy(cube);

        _activeCubes.RemoveAt(lastCube);
  }*/
}
