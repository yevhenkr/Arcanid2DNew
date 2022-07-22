using System;
using UnityEngine;

public class BottomBoard : MonoBehaviour
{
    public event Action OnBallTouchBottom;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Ball ball))
        {
            OnBallTouchBottom?.Invoke();
            Destroy(ball.gameObject);
        }
    }
}
