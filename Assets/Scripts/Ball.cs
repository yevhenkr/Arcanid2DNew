using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action OnBollCollider;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Block block))
        {
            OnBollCollider?.Invoke();
        }
    }
}
