using UnityEngine;

public class HitBox : MonoBehaviour, IDamagable
{
    [SerializeField] private PlayerController _player;

    public void TakeDamage(bool isHit)
    {
        _player.TakeDamage();
    }
}
