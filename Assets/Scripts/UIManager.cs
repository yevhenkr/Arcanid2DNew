using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private RightPanel rightPanel;
    [SerializeField] private CounterPanel counter;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnRestart;
    public event Action OnPushStart;
    public event Action OnPushRestart;

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
        btnRestart.onClick.AddListener(() => PushRestartButton());

    }
    public void PushRestartButton()
    {
        OnPushRestart?.Invoke();
    }
    public void CounterAddOne()
    {
        counter.AddedCount();
    }
}