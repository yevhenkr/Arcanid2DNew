using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBlocks: MonoBehaviour
{
    [SerializeField] private int poolCount = 3;     
    [SerializeField] private bool autoExpand = false; 
    [SerializeField] private Block blockPrefab;
    private PoolMono<Block> pool;
    private int columnCount = 5;
    [SerializeField] private List<GameObject> poolBloks;

    private void Start()
    {
        this.pool = new PoolMono<Block>(this.blockPrefab, this.poolCount, this.transform);
        //this.pool.autoExpand = this.autoExpand; 
    }

    public void GenerationBlocks()
    {
        float blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        float blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        float xOffset = blockWidth + blockWidth / 10;
        float yOffset = blockHeight + blockHeight / 10;
        var xPos = blockPrefab.GetComponent<Transform>().position.x;
        var firstPos = blockPrefab.GetComponent<Transform>().position.x;
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
                xPos = firstPos;
                //poolBloks.Add(bullet);
                yPos -= yOffset;
            }
            this.CreateBlock(xPos, yPos);
            //Vector2 tilePosition = new Vector2(xPos, yPos);
            //var bullet = Pools.PoolsManager.GetObject(blockPrefab.name, tilePosition, Quaternion.Euler(Vector3.zero));
            xPos += xOffset;

        }
    }

        private void CreateBlock(float xPos, float yPos)
    {
        var pos = new  Vector2(xPos, yPos);
        var block = this.pool.GetFreeElement();
        block.transform.position = pos;
    }
}