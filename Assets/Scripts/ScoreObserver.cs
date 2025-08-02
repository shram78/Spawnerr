using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private PlayerController _playerController;
    
    private int _enemyKilledCount = 0;

    private void Start()
    {
        _scoreView.ShowEnemyKilled(_enemyKilledCount);
    }

    private void OnEnable()
    {
        _playerController.OnLivesChanged += ShowPlayerLives;
    }

    private void ShowPlayerLives(int lives)
    {
        _scoreView.ShowPlayerLives(lives);
    }

    public void EnemyDestroed()
    {
        _enemyKilledCount++;
        _scoreView.ShowEnemyKilled(_enemyKilledCount);
    }

    private void OnDisable()
    {
        _playerController.OnLivesChanged -= ShowPlayerLives;
    }
  }
