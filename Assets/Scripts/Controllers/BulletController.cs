using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5;
    [SerializeField] private float _lifeTime = 2;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private GameObject _explosionVFX;
    private Transform _bulletFolder;
    
    private void Start()
    {
       _audioSource.PlayOneShot(_shootSound);
        
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.TakeDamage(true);
            GameObject vfx = Instantiate(_explosionVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 0.5f);
            Destroy(gameObject, 1);
        }
    }
}
