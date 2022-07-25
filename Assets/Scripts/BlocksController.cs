using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Vector2 mapBlocks;
    [SerializeField] private List<GameObject> poolBloks;
    List<string> listBlocksCollor = new List<string>(){"red", "green", "blue", "yellow","pink"};


    private void Start()
    {
        poolBloks = new List<GameObject>();
    }

    public void GenerationBlocks()
    {
        float blockWidth = blockPrefab.GetComponent<BoxCollider2D>().size.x;
        float blockHeight = blockPrefab.GetComponent<BoxCollider2D>().size.y;
        float xOffset = blockWidth + blockWidth / 10;
        float yOffset = blockHeight + blockHeight / 10;

        var yPos = blockPrefab.GetComponent<Transform>().position.y;
        for (int x = 0; x < mapBlocks.x; x++)
        {
            var xPos = blockPrefab.GetComponent<Transform>().position.x;
            for (int y = 0; y < mapBlocks.y; y++)
            {
                Vector2 tilePosition = new Vector2(xPos, yPos);
                var bullet =
                    Pools.PoolsManager.GetObject(blockPrefab.name, tilePosition, Quaternion.Euler(Vector3.zero));
                // var block = Instantiate(blockPrefab, tilePosition, Quaternion.Euler(Vector3.zero));
                // block.GetComponent<Block>().OnDestroy += DestroyObjectEvent;
                string randomColor = listBlocksCollor[Random.Range(0, listBlocksCollor.Count)];
                bullet.GetComponent<SpriteRenderer>().sprite =  Resources.Load($"images/{randomColor}", typeof(Sprite)) as Sprite;

                xPos += xOffset;
                poolBloks.Add(bullet);
            }

            yPos -= yOffset;
        }
    }
    public void AllBlocksToPool()
    {
        for (int i = 0; i < poolBloks.Count; i++)
        {
            poolBloks[i].SetActive(false);
        }
    }
}