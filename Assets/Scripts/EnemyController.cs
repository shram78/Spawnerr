using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;
    
    private int _currentSpawnIndex;
    private float _timer;
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            Shoot();
            _timer = 0;
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
}
