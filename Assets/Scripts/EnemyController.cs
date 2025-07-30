using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    public void TakeDamage(bool isHit)
    {
        EnemySpawner enemySpawner = FindFirstObjectByType<EnemySpawner>();
        
        enemySpawner.IdentKilledEnemy(this);
    }
}
