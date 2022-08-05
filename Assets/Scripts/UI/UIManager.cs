using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MenuPanel menuPanel;
    [SerializeField] private WinPanel winPanel;
    [SerializeField] private RightPanel rightPanel;
    [SerializeField] private CounterPanel counter;
    
    [SerializeField] private Button btnRestart;
    public event Action OnPushStart;
    public event Action OnPushRestart;

    public void Init()
    {
        menuPanel.btnStart.onClick.AddListener(() => PushStartButton());
    }

    public void ShowMenu()
    {
        menuPanel.Show();
        counter.FerstStart();
        rightPanel.SetActiveFalce();
    }

    public void PushStartButton()
    {
        OnPushStart?.Invoke();
        menuPanel.Hide();
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

    public float GetTime()
    {
        return rightPanel.GetTime();
    }

    public void ShowWinPanel(BestScoreStruct bestScoreStruct)
    {
        winPanel.SetIsActive(true);
        winPanel.ShowScoreBestPanel(bestScoreStruct);
    }
}