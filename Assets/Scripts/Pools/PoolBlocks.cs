using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolBlocks : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private int poolCount = 3;
    [SerializeField] private int columnCount = 5;
    [SerializeField] private Sprite[] listSprites;
    [SerializeField] private Sprite[] countPrefabType;
    private PoolMono pool;
    private float blockWidth;
    private float blockHeight;
    private float xOffset;
    private float yOffset;
    private float startPosX;
    private bool firstStart;
    private float xPosPrefab;
    private float yPosPrefab;

    public event Action EventBallDestroyBlock;
    private void Start()
    {
        xPosPrefab = blockPrefab.GetComponent<Transform>().position.x;
        yPosPrefab = blockPrefab.GetComponent<Transform>().position.y;
        blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        xOffset = blockWidth + blockWidth / 10;
        yOffset = blockHeight + blockHeight / 10;
        startPosX = blockPrefab.GetComponent<Transform>().position.x;
        this.pool = new PoolMono(this.blockPrefab.gameObject, this.poolCount, this.transform);
        firstStart = true;
    }

    public void InitBlocks()
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
            this.SetParametrInBlock(xPosPrefab, yPosPrefab);
            xPosPrefab += xOffset;
        }
        firstStart = false;
    }
    
    private void SetParametrInBlock(float xPos, float yPos)
    {

        var block = this.pool.GetFreeElement();
        if (firstStart)
        {
            var pos = new Vector2(xPos, yPos);
            block.transform.position = pos;
            block.GetComponent<Block>().EventDestroyBlock += BallDestroyBlock;
        }

        int typePrefab = Random.Range(0, listSprites.Length);
        SetHealthValue(block, typePrefab);
        SetSprite(block, typePrefab);
        
    }

    public void SetHealthValue(GameObject createadObject, int typePrefab)
    {
        createadObject.GetComponent<Block>().SetHealthValue(typePrefab);
    }

    public void SetSprite(GameObject createadObject, int typePrefab)
    {
        var t = listSprites[typePrefab];
        createadObject.GetComponent<Block>().SetSprite(t);
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
    }
}