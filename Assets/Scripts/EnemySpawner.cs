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
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval &&  _isTutorialComplete)
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
        GameObject enemy = Instantiate(_enemyPrefab, _spawnPoints[spawnIndex].position, _spawnPoints[spawnIndex].rotation, _spawnFolder);
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.IdentIndex(spawnIndex);
    }

    public void TryToKill(int index)
    {
            _isCellBusy[index] = false;
    }

    public void StartSpawn()
    {
        _isTutorialComplete = true;
    }
}
