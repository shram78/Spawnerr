using System;
using TMPro;
using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private CubePool _cubePool;

    private void Start()
    {
        _cubePool.OnSpawnedCountChanged += _scoreView.Display;
    }

    private void OnDestroy()
    {
        _cubePool.OnSpawnedCountChanged -= _scoreView.Display;
    }
  }
