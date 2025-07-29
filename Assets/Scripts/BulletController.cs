using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5;
    [SerializeField] private float _lifeTime = 2;
    
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
    }
}
