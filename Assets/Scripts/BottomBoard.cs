using System;
using UnityEngine;

public class BottomBoard : MonoBehaviour
{
    public event Action EventBallIsTouchButtom;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Ball block))
        {
            EventBallIsTouchButtom?.Invoke();
        }
    }
}