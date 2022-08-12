using UnityEngine;

public class BlockConstruсtor : MonoBehaviour
{
    public void SetHealthValue(GameObject createadObject, int typePrefab)
    {
        createadObject.GetComponent<Block>().SetHealthValue(typePrefab);
    }

    public void SetSprite(GameObject createadObject, Sprite sprite)
    {
        createadObject.GetComponent<Block>().SetSprite(sprite);
    }
}