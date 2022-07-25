using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private RightPanel rightPanel;
    [SerializeField] private CounterPanel counter;
    public event Action OnPushStart;


    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        counter.FerstStart();
        rightPanel.SetActiveFalce();
    }

    public void PushStartButton()
    {
        OnPushStart?.Invoke();
        menuPanel.SetActive(false);
        rightPanel.SetActive();
    }

    public void CounterAddOne()
    {
        counter.AddedCount();
    }
}