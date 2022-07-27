using UnityEngine;
using UnityEngine.UI;

public class CounterPanel : MonoBehaviour
{
    [SerializeField] Text counter;
    private int zero;

    private int count;

    public void FerstStart()
    {
        gameObject.SetActive(true);
        ResetValue();
    }

    public void ResetValue()
    {
        counter.text = zero.ToString();
        count = zero;
    }

    public void AddedCount()
    {
        int.TryParse(counter.text, out count);
        count++;
        counter.text = count.ToString();
    }
}