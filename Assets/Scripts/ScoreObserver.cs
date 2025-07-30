using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [FormerlySerializedAs("_cubePool")] [SerializeField] private EnemyPool enemyPool;

    private void Start()
    {
        enemyPool.OnSpawnedCountChanged += _scoreView.Display;
    }

    private void OnDestroy()
    {
        enemyPool.OnSpawnedCountChanged -= _scoreView.Display;
    }
  }
