using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolBlocks : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private BlockConstruсtor blockConstruсtor;
    [SerializeField] private int poolCount;
    [SerializeField] private int columnCount;
    [SerializeField] private Sprite[] listSprites;
    private PoolMono pool;
    private float blockWidth;
    private float blockHeight;
    private float xOffset;
    private float yOffset;
    private float startPosX;
    private bool firstStart;
    private float xPosPrefab;
    private float yPosPrefab;
    private float blocksOnScene;

    public event Action EventBallDestroyBlock;
    public event Action AllBlocksDestroy;

    public void Init()
    {
        xPosPrefab = blockPrefab.GetComponent<Transform>().position.x;
        yPosPrefab = blockPrefab.GetComponent<Transform>().position.y;
        startPosX = blockPrefab.GetComponent<Transform>().position.x;
        blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        xOffset = blockWidth + blockWidth / 10;
        yOffset = blockHeight + blockHeight / 10;
        this.pool = new PoolMono(this.blockPrefab.gameObject, this.poolCount, this.transform);
        firstStart = true;
        blocksOnScene = poolCount;
    }

    public void ShowBlocks()
    {
        var currentColumn = 0;
        var currentBlock = 0;
        for (int x = 0; x < poolCount; x++)
        {
            currentBlock++;
            currentColumn++;
            if (currentColumn == columnCount + 1)
            {
                currentColumn = 1;
                xPosPrefab = startPosX;
                yPosPrefab -= yOffset;
            }

            var block = this.pool.GetFreeElement();
            if (firstStart)
            {
                block.transform.position = new Vector2(xPosPrefab, yPosPrefab);
                block.GetComponent<Block>().EventDestroyBlock += BallDestroyBlock;
            }

            int blockType = Random.Range(0, listSprites.Length);

            blockConstruсtor.SetHealthValue(block, blockType + 1);
            blockConstruсtor.SetSprite(block, listSprites[blockType]);
            xPosPrefab += xOffset;
        }

        firstStart = false;
    }

    public void HideAllObjectsToPool()
    {
        this.pool.HideAllObjectsToPool();
    }

    public void ShowAllObjectsToPool()
    {
        this.pool.ShowAllObjectsToPool();
    }

    public void BallDestroyBlock()
    {
        EventBallDestroyBlock?.Invoke();
        blocksOnScene--;
        if (0 == blocksOnScene)
        {
            AllBlocksDestroy?.Invoke();
        }
    }
}