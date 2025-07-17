using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CubePool : MonoBehaviour
{

    [SerializeField] private GameObject _cubePrefab;

    private int _poolSize = 10;
    private Queue<GameObject> _pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject cube = Instantiate(_cubePrefab);
            cube.gameObject.SetActive(false);
            _pool.Enqueue(cube);
        }
    }

    public GameObject TakeCube()
    {
        if (_pool.Count > 0)
        {

            GameObject cube = _pool.Dequeue();
            cube.SetActive(true);

            return cube;
        }
        else
        {
            GameObject cube = Instantiate(_cubePrefab);

            return cube;

        }

    }

    public void ReturnCube(GameObject cube)
    {
        cube.SetActive(false);
        _pool.Enqueue(cube);
    }
}
