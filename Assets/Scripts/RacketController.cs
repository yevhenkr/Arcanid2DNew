using System;
using UnityEngine;

public class RacketController : MonoBehaviour
{ 
    public event Action OnGameLose;
    private GameObject racket;
    private GameObject ball;

    public void SpawnBall()
    {
        ball = Instantiate(Resources.Load("Ball") as GameObject);
        ball.GetComponent<Ball>().OnBollTouchButtom += DestroyBall;
    }

    public void SpawnPlatform()
    {
        racket = Instantiate(Resources.Load("Platform") as GameObject);
    }

    public void DestroyRacket()
    {
        Destroy(racket);
    }

    public void DestroyBall()
    {
        OnGameLose?.Invoke();
    }
}