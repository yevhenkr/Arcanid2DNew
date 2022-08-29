using System;
using UnityEngine;
using UnityEngine.UI;

public class CountBloksPanel : MonoBehaviour
{
    [SerializeField] private Button plus;
    [SerializeField] private Button minus;
    [SerializeField] private Text choseCount;

    private SaveCountBlock saveCount;

    public void Init()
    {
        plus.onClick.AddListener(() => Plus());
        minus.onClick.AddListener(() => Minus());
        saveCount = new SaveCountBlock();
        SetCount(saveCount.Load("countBlocks"));
    }

    private void Plus()
    {
        var count = Convert.ToInt32(choseCount.text);
        if (Config.MaxCoutsBlocks > count)
        {
            choseCount.text = (++count).ToString();
            saveCount.Save(count);

        }
    }
    private void Minus()
    {
        var count = Convert.ToInt32(choseCount.text);
        if (count > 0)
        {
            choseCount.text = (--count).ToString();
            saveCount.Save(count);
        }
    }
    private void SetCount(int count)
    {
            choseCount.text = count.ToString();
    }

}
