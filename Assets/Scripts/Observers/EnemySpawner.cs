using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private GameObject _enemyPrefab;

    private bool[] _isCellBusy;
    private float _timer;
    private Transform _spawnFolder;
    private bool _isTutorialComplete = false;

    private int _enemyInWaveCount = 0;
    private int _aliveEnemyInWave = 0;
    private int _currentWave = 0;

    public event Action<int> OnWaveChanged;
    public event Action<int> OnEnemyAliveChanged;
    
    
    private void Awake()
    {
        GameObject folder = GameObject.Find("SpawnedObjects");
        if (folder == null)
            folder = new GameObject("SpawnedObjects");

        _spawnFolder = folder.transform;
    }
    
    private void Start()
    {
        _isCellBusy = new bool[_spawnPoints.Length];
        
        SetNewWave();
        
        OnWaveChanged?.Invoke(_currentWave);
        
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval &&  _isTutorialComplete && _enemyInWaveCount > 0)
        {
            FindSpawnPosition();
            _timer = 0;
        }

        if (_aliveEnemyInWave == 0)
        {
            SetNewWave();
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

    private void SetNewWave()
    {
        _currentWave++;
        
        _enemyInWaveCount = _currentWave * 2;

        _aliveEnemyInWave = _enemyInWaveCount;
        
        OnEnemyAliveChanged?.Invoke(_aliveEnemyInWave);
        OnWaveChanged?.Invoke(_currentWave);
    }

    private void Spawn(int spawnIndex)
    {
        GameObject enemy = Instantiate(_enemyPrefab, _spawnPoints[spawnIndex].position, _spawnPoints[spawnIndex].rotation, _spawnFolder);
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.IdentIndex(spawnIndex);

        _enemyInWaveCount--;
    }


    public void TryToKill(int index)
    {
            _isCellBusy[index] = false;

            _aliveEnemyInWave--;
            OnEnemyAliveChanged?.Invoke(_aliveEnemyInWave);
    }

    public void StartSpawn()
    {
        _isTutorialComplete = true;
    }
}
