using UnityEngine;

public class SaveScore: MonoBehaviour
{
    public void SetFloat(string countBlock, float time)
    {
        PlayerPrefs.SetFloat(countBlock, time);
    }
    public void GetFloat(string countBlock)
    {
        print(PlayerPrefs.GetFloat(countBlock));
    }
}
