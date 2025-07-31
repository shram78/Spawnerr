using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    private int _currentSpawnIndex;
    
    public void TakeDamage(bool isHit)
    {
        EnemySpawner enemySpawner = FindFirstObjectByType<EnemySpawner>();
        
        enemySpawner.TryToKill(_currentSpawnIndex);
        
        Destroy(gameObject);
    }

    public void IdentIndex(int identIndex)
    {
        _currentSpawnIndex = identIndex;
    }
}
