using UnityEngine;

public class RacketController : MonoBehaviour
{
    private GameObject racket;

    public void SpawnBall()
    {
        GameObject ball = Instantiate(Resources.Load("Ball") as GameObject);
    }

    public void SpawnPlatform()
    {
        racket = Instantiate(Resources.Load("Platform") as GameObject);
    }


    public void DestroyRacket()
    {
        Destroy(racket);
    }
}