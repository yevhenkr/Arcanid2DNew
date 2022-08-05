using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action OnBollCollider;
    public event Action OnBollTouchButtom;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Block block))
        {
            OnBollCollider?.Invoke();
        }

        if (collider.gameObject.TryGetComponent(out BottomBoard bottomBoard))
        {
            OnBollTouchButtom?.Invoke();
            DestroyBoll();
        }
    }

    public void DestroyBoll()
    {
        Destroy(this.gameObject);
    }
}