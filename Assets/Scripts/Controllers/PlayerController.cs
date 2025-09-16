using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]  

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private UI_Tutorial _uiTutorial;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _buletsPrefabFolder;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private CameraShake _cameraShake;
    
    private Rigidbody _rb;
    private int _lives = 5;
    private bool _isPlayerStartedMove = false;
    private bool _isMoveLeft = false;
    private bool _isMoveRight = false;
    
    public event Action<int> OnLivesChanged;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        OnLivesChanged?.Invoke(_lives);
        
        _leftButton.onClick.AddListener(() => { });
        _rightButton.onClick.AddListener(() => { });
    }

    public void OnPointerDownButton() => _isMoveLeft = true;
    public void OnPointerUpButton() => _isMoveLeft = false;
    
    public void OnPointerDownButtonR() => _isMoveRight = true;
    public void OnPointerUpButtonR() => _isMoveRight = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this != null)
            Shoot();

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
           FinishTutorial();
        }
        
        if (_isMoveLeft)
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            FinishTutorial();
        }
        if (_isMoveRight)
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
            FinishTutorial();
        }
    }

    private void FinishTutorial()
    {
        _isPlayerStartedMove = true;
         
        _uiTutorial.HiddenButton();
            
        _enemySpawner.StartSpawn();
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
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity, _buletsPrefabFolder);
    }

    public void TakeDamage()
    {
        _lives--;
        _cameraShake.Shake();
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
