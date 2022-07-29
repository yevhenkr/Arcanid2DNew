using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private RightPanel rightPanel;
    [SerializeField] private CounterPanel counter;
    [SerializeField] private Button btnStart;
    public event Action OnPushStart;

    public void Init()
    {
        btnStart.onClick.AddListener(() => PushStartButton());
    }

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