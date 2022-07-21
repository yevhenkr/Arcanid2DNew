using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public event Action BallTouchedBlock;
    public void SpawnBall()
    {
        GameObject ball = Instantiate (Resources.Load ("Ball") as GameObject);
        ball.GetComponent<Ball>().OnBollCollider += BallTouchBlock;
    }
     public void SpawnPlatform()
    {
        Instantiate (Resources.Load ("Platform") as GameObject);
    }

    public void BallTouchBlock()
    {
        BallTouchedBlock?.Invoke();
    }
}
