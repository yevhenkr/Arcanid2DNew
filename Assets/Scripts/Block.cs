using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action EventDestroyBlock;
    public event Action<BlockData> BallData;
    [SerializeField] private int healthPoints;

    void OnCollisionEnter2D(Collision2D col)
    {
        healthPoints--;
        if (healthPoints == 0)
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        EventDestroyBlock?.Invoke();
        gameObject.SetActive(false);
    }

    public void SetHealthValue(int health)
    {
        healthPoints = health;
    }

    public void SetSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}