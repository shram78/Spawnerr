using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private CubePool _cubePool;

    private List<GameObject> _activeCubes = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();

        if (Input.GetKeyDown(KeyCode.Q))
            ReturnCube();

    }

    private void Spawn()
    {
        GameObject cube = _cubePool.TakeCube();

        cube.transform.position = SpawnPoint.transform.position;
        cube.transform.rotation = Quaternion.identity;

        _activeCubes.Add(cube);
    }

    private void ReturnCube()
    {
        if (_activeCubes.Count == 0) return;

        int lastCube = _activeCubes.Count - 1;

        GameObject cube = _activeCubes[lastCube];
        _cubePool.ReturnCube(cube);

        _activeCubes.RemoveAt(lastCube);
    }
}
