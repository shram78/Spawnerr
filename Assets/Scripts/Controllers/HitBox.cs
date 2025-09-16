using UnityEngine;

public class HitBox : MonoBehaviour, IDamagable
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitSound;

    public void TakeDamage(bool isHit)
    {
       _audioSource.PlayOneShot(_hitSound);
        
        _player.TakeDamage();
    }
}
