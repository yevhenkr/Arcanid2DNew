using UnityEngine;

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
    private void Start()
    {
        blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        xOffset = blockWidth + blockWidth / 10;
        yOffset = blockHeight + blockHeight / 10;
        startPosX = blockPrefab.GetComponent<Transform>().position.x;
        this.pool = new PoolMono(this.blockPrefab.gameObject, this.poolCount, this.transform);
        
    }

    public void GenerationBlocks()
    {
        var xPos = blockPrefab.GetComponent<Transform>().position.x;
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
}