using TMPro;
using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private CubePool _cubePool;

    void Start()
    {
        _cubePool.OnSpawnedCountChanged += _scoreView.Display;
    }
 
}
