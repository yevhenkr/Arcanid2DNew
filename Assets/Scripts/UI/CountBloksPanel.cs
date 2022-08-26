using System;
using UnityEngine;
using UnityEngine.UI;

public class CountBloksPanel : MonoBehaviour
{
    [SerializeField] private Button plus;
    [SerializeField] private Button minus;
    [SerializeField] private Text choseCount;
    private string amountBlock;

    public void Init()
    {
        plus.onClick.AddListener(() => Plus());
        minus.onClick.AddListener(() => Minus());
        amountBlock = choseCount.text;
    }

    private void Plus()
    {
        var count = Convert.ToInt32(choseCount.text);
        if (Config.MaxCoutsBlocks > count)
            choseCount.text = (++count).ToString();
    }
    private void Minus()
    {
        var count = Convert.ToInt32(choseCount.text);
        if (count > 0)
            choseCount.text = (--count).ToString();
    }
}
