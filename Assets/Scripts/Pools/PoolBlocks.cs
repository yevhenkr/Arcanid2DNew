using UnityEngine;

public class PoolBlocks : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private int poolCount = 3;    
    [SerializeField] private int columnCount = 5;
    private PoolMono<Block> pool;
    private float blockWidth;
    private float blockHeight;

    private void Start()
    {
        blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        this.pool = new PoolMono<Block>(this.blockPrefab, this.poolCount, this.transform);
    }

    public void GenerationBlocks()
    {
        float xOffset = blockWidth + blockWidth / 10;
        float yOffset = blockHeight + blockHeight / 10;
        var xPos = blockPrefab.GetComponent<Transform>().position.x;
        var startPosX = blockPrefab.GetComponent<Transform>().position.x;
        var yPos = blockPrefab.GetComponent<Transform>().position.y;
        var currentColumn = 0;
        var currentBlock = 0;

        for (int x = 0; x < poolCount; x++)
        {
            currentBlock++;
            currentColumn++;
            if (currentColumn == columnCount + 1)
            {
                currentColumn = 1;
                xPos = startPosX;
                yPos -= yOffset;
            }

            this.CreateBlock(xPos, yPos);
            xPos += xOffset;
        }
    }

    private void CreateBlock(float xPos, float yPos)
    {
        var pos = new Vector2(xPos, yPos);
        var block = this.pool.GetFreeElement();
        block.transform.position = pos;
    }

    public void HideAllObjectsToPool()
    {
        this.pool.HideAllObjectsToPool();
    }
}