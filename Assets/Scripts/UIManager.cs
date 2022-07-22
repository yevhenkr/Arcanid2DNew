using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private CounterPanel counter;
    public event Action OnPushStart;


    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        counter.FerstStart();
    }

    public void PushStartButton()
    {
        OnPushStart?.Invoke();
        menuPanel.SetActive(false);
    }

    public void CounterAddOne()
    {
        counter.AddedCount();
    }
}