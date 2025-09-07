using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private UI_Tutorial _uiTutorial;
    [SerializeField] private EnemySpawner _enemySpawner;
    
    private Rigidbody _rb;
    private int _lives = 3;
    private bool _isPlayerStartedMove = false;
    
    public event Action<int> OnLivesChanged;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        OnLivesChanged?.Invoke(_lives);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this != null)
            Shoot();

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _isPlayerStartedMove = true;
         
            _uiTutorial.HiddenButton();
            
            _enemySpawner.StartSpawn();
        }
    }

    private void FixedUpdate()
    {
        if (_isPlayerStartedMove == false) return;
        
        float inputX = Input.GetAxis("Horizontal");
        Vector3 newVelocity = new Vector3(inputX * _moveSpeed, _rb.linearVelocity.y, _rb.linearVelocity.z);
        _rb.linearVelocity = newVelocity;
    }

    private void Shoot()
    {
        if (this != null)
        Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        _lives--;
        OnLivesChanged?.Invoke(_lives);

        if (_lives <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    public void GetFireButtonTutorial()
    {
        Shoot();
    }
}
