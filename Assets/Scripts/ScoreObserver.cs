using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private EnemySpawner _enemySpawner;
    
    private int _enemyKilledCount = 0;

    private void Start()
    {
        _scoreView.SetEnemyKilled(_enemyKilledCount);
    }

    private void OnEnable()
    {
        _playerController.OnLivesChanged += ShowPlayerLives;
        _enemySpawner.OnWaveChanged += ShowCurrentWave;
        _enemySpawner.OnEnemyAliveChanged += ShowAliveEnemy;
    }

    private void ShowPlayerLives(int lives)
    {
        _scoreView.SetPlayerLives(lives);
    }

    public void EnemyDestroed()
    {
        _enemyKilledCount++;
        _scoreView.SetEnemyKilled(_enemyKilledCount);
    }

    private void ShowCurrentWave(int wave)
    {
        _scoreView.SetCurrentWave(wave);
    }

    private void ShowAliveEnemy(int alive)
    {
        _scoreView.SetAliveEnemy(alive);
    }

    private void OnDisable()
    {
        _playerController.OnLivesChanged -= ShowPlayerLives;
        _enemySpawner.OnWaveChanged -= ShowCurrentWave;
        _enemySpawner.OnEnemyAliveChanged -= ShowAliveEnemy;
    }
  }
