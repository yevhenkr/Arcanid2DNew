using UnityEngine;

public class SaveTypeGame : MonoBehaviour, ISystemSave<int>
{
    public void Save(float nuberTypeBlock,string typeBlock = "typeBlock")
    {
        PlayerPrefs.SetFloat(typeBlock, nuberTypeBlock);
    }
    public int Load(string typeBlock = "typeBlock", float type = -1)
    {
        var selectTypeBlock = PlayerPrefs.GetFloat(typeBlock);
        return (int)selectTypeBlock;
    }
}
