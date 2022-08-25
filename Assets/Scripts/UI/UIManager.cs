using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private WinPanel winPanel;
    [SerializeField] private RightPanel rightPanel;
    [SerializeField] private CounterPanel counter;
    [SerializeField] private GameObject pauseLayer;
    private int typeBtn;
    
    [SerializeField] private Button btnRestart;
    [SerializeField] private ButtonPause btnPause;
    public event Action OnPushRestart;
    private void Awake()
    {
        btnPause.ValueChanged += OnPauseClicked;
        btnRestart.onClick.AddListener(() => RestartButtonPush());

    }

    public void ShowMenu()
    {
        counter.FerstStart();
        rightPanel.Show();
    }

    public void RestartButtonPush()
    {
        OnPushRestart?.Invoke();
    }

    public void OnPauseClicked(bool isPaused)
    {
        ProjectContext.Instance.PauseManager.SetPaused(isPaused);
        pauseLayer.SetActive(isPaused);
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