using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Shake()
    {
        transform.DOShakePosition(0.5f, 0.3f, 10, 90, false, true);
    }
}
