using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action EventDestroyBlock;
    [SerializeField] private int healthPoint;

    public void SetHealthValue(int health)
    {
        healthPoint = health;
    }

    public void SetSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        healthPoint--;
        if (healthPoint == 0)
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        EventDestroyBlock?.Invoke();
        gameObject.SetActive(false);
    }
}