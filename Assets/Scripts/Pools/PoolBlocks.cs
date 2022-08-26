using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolBlocks : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private BlockConstruсtor blockConstruсtor;
    [SerializeField] private int columnCount;
    [SerializeField] private Sprite[] listSprites;
        
    private int poolCount;
    private PoolMono pool;
    private List<bool> visibleBlocks;
    private SaveCountBlock saveCountBlock;
    private float blockWidth;
    private float blockHeight;
    private float xOffset;
    private float yOffset;
    private float startPosX;
    private bool firstStart;
    private float xPosPrefab;
    private float yPosPrefab;
    private float blocksOnScene;
    private float countCisibleBlock;
    public int DestroyBlock { get; private set; }

    public event Action EventBallDestroyBlock;
    public event Action AllBlocksDestroy;

    public void Init()
    {
        poolCount = Config.MaxCoutsBlocks;
        visibleBlocks = new List<bool>(Config.MaxCoutsBlocks);
        SetListFalse();
        saveCountBlock = new SaveCountBlock();
        countCisibleBlock = saveCountBlock.Load("countBlocks");
        xPosPrefab = blockPrefab.GetComponent<Transform>().position.x;
        yPosPrefab = blockPrefab.GetComponent<Transform>().position.y;
        startPosX = blockPrefab.GetComponent<Transform>().position.x;
        blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        xOffset = blockWidth + blockWidth / 10;
        yOffset = blockHeight + blockHeight / 10;
        this.pool = new PoolMono(this.blockPrefab.gameObject, this.poolCount, this.transform);
        firstStart = true;
    }

    public void ShowBlocks(int typeButton)
    {
        ChoseVisibleBlock(countCisibleBlock);
        DestroyBlock = 0;
        var currentColumn = 0;
        var currentBlock = 0;

        for (int x = 0; x < poolCount; x++)
        {
            currentBlock++;
            currentColumn++;
            if (currentColumn == columnCount + 1){
                currentColumn = 1;
                xPosPrefab = startPosX;
                yPosPrefab -= yOffset;
            }
            if (visibleBlocks[x] == true){

                var block = this.pool.GetFreeElement();
                if (firstStart){
                block.transform.position = new Vector2(xPosPrefab, yPosPrefab);
                block.GetComponent<Block>().EventDestroyBlock += BallDestroyBlock;
                }
                if (typeButton == (int)TypeButtonStart.Random)
                {
                    var blockType = Random.Range(0, listSprites.Length);
                    blockConstruсtor.SetHealthValue(block, blockType + 1);
                    blockConstruсtor.SetSprite(block, listSprites[blockType]);
                }
                else
                {
                    blockConstruсtor.SetHealthValue(block, typeButton + 1);
                    blockConstruсtor.SetSprite(block, listSprites[typeButton]);
                }
            }
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
        DestroyBlock++;

        if (0 == blocksOnScene)
        {
            AllBlocksDestroy?.Invoke();
        }
    }

    private void SetListFalse()
    {
        for (int i = 0; i < Config.MaxCoutsBlocks; i++)
        {
            visibleBlocks.Add(false);
        }
    }

    private void ChoseVisibleBlock(float coutBlock)
    {
        for (int i = 0; i < coutBlock; i++)
        {
            int randomPosition = Random.Range(0, Config.MaxCoutsBlocks);
            if (visibleBlocks[randomPosition] == false)
            {
                visibleBlocks[randomPosition] = true;
            }
            else
            {
                ++i;
            }
        }

    }
}