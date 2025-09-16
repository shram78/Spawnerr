using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _spawnInterval = 1;
    private float _timer;

    public event Action OnTimerDone;
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            OnTimerDone?.Invoke();
            
            _timer = 0;
        }
    }
}
