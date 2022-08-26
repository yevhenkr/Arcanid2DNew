using UnityEngine;

public class SaveCountBlock : MonoBehaviour, ISystemSave<int>
{
    public void Save(float nuberTypeBlock, string countBlocks = "countBlocks")
    {
        PlayerPrefs.SetFloat(countBlocks, nuberTypeBlock);
    }
    public int Load(string countBlocks = "countBlocks", float count = -1)
    {
        var selectCountBlock = PlayerPrefs.GetFloat(countBlocks);
        return (int)selectCountBlock;
    }
}
