using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  

public class PlayerController : MonoBehaviour,  IDamagable
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    
    private Rigidbody _rb;
    private int _lives = 3;
    
    public event Action<int> OnLivesChanged;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        OnLivesChanged?.Invoke(_lives);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 newVelocity = new Vector3(inputX * _moveSpeed, _rb.linearVelocity.y, _rb.linearVelocity.z);
        _rb.linearVelocity = newVelocity;
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
    }

    public void TakeDamage(bool isHit)
    {
        _lives--;
        OnLivesChanged?.Invoke(_lives);

        if (_lives <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
