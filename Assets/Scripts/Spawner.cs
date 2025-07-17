using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _lifeTime;

    private List<GameObject> _activeCubes = new List<GameObject>();

    private float _timer;
    

    void Update()
    {
        _timer += Time.deltaTime;     

        if (_timer >= _spawnInterval)
        {
            Spawn();

            _timer = 0;
        }
    }

    private void Spawn()
    {
        Transform SpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];

        GameObject cube = _cubePool.TakeCube();

        cube.transform.position = SpawnPoint.transform.position;
        cube.transform.rotation = Quaternion.identity;

        _activeCubes.Add(cube);

        StartCoroutine(DisableByTimer());
    }

    private void ReturnCube()
    {
        if (_activeCubes.Count == 0) return;

        int lastCube = _activeCubes.Count - 1;

        GameObject cube = _activeCubes[lastCube];
        _cubePool.ReturnCube(cube);

        _activeCubes.RemoveAt(lastCube);
    }

    private IEnumerator DisableByTimer()
    {
        yield return new WaitForSeconds(_lifeTime);

        ReturnCube();

        StopAllCoroutines();
    }
}
