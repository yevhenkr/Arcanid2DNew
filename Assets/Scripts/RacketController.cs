using System;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public event Action BallTouchedBlock;
    private GameObject racket;

    public void SpawnBall()
    {
        GameObject ball = Instantiate(Resources.Load("Ball") as GameObject);
        ball.GetComponent<Ball>().OnBollCollider += BallTouchBlock;
    }

    public void SpawnPlatform()
    {
        racket = Instantiate(Resources.Load("Platform") as GameObject);
    }

    public void BallTouchBlock()
    {
        BallTouchedBlock?.Invoke();
    }

    public void DestroyRacket()
    {
        Destroy(racket);
    }
}