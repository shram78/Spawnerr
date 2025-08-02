using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;
    
    private float _minIntervalToShoot = 0.2f;
    private float _maxIntervalToShoot = 1.5f;
    private float _currentIntervaltoShoot;
    private int _currentSpawnIndex;
    private float _timer;

    private void Start()
    {
        SetRandomIntervalToShoot();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _currentIntervaltoShoot)
        {
            Shoot();
            _timer = 0f;
            SetRandomIntervalToShoot();
        }
    }
    
    public void TakeDamage(bool isHit)
    {
        EnemySpawner enemySpawner = FindFirstObjectByType<EnemySpawner>();
        enemySpawner.TryToKill(_currentSpawnIndex);
        
        ScoreObserver scoreObserver = FindFirstObjectByType<ScoreObserver>();
        scoreObserver.EnemyDestroed();
        
        Destroy(gameObject);
    }

    public void IdentIndex(int identIndex)
    {
        _currentSpawnIndex = identIndex;
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.Euler(0f, 180f, 0f));
    }

    private void SetRandomIntervalToShoot()
    {
        _currentIntervaltoShoot = Random.Range(_minIntervalToShoot, _maxIntervalToShoot);
    }
}
