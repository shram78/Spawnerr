using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private ScoreObserver _scoreObserver;
    [SerializeField] private Timer _timer;

    private bool[] _isCellBusy;
    private Transform _spawnFolder;
    private bool _isTutorialComplete = false;
    private bool _isWaveMessageShowed = false;
    private int _enemyInWaveCount = 0;
    private int _aliveEnemyInWave = 0;
    private int _currentWave = 0;
    private float _timeToShowInfoWave = 4;

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

    private void OnEnable()
    {
        _timer.OnTimerDone += TryToSpawn;
    }

    private void OnDestroy()
    {
         StopCoroutine(TimerBeforeNewWave());
    }

    private void TryToSpawn()
    {
        if (_isTutorialComplete && _enemyInWaveCount > 0 && !_isWaveMessageShowed)
            FindSpawnPosition(); 

        if (_aliveEnemyInWave == 0)
            SetNewWave();
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
        StartCoroutine(TimerBeforeNewWave());
        
        _currentWave++;
        _scoreObserver.ShowInfoBeforeNewWave(_currentWave);
        
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

    IEnumerator TimerBeforeNewWave()
    {
        _isWaveMessageShowed = true;
        
        yield return new WaitForSeconds(_timeToShowInfoWave);
        
        _scoreObserver.HideInfoBeforeNewWave();
        _isWaveMessageShowed = false;
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
    
    private void OnDisable()
    {
        _timer.OnTimerDone -= TryToSpawn;
    }
}
