using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MenuPanel menuPanel;
    [SerializeField] private WinPanel winPanel;
    [SerializeField] private RightPanel rightPanel;
    [SerializeField] private CounterPanel counter;
    [SerializeField] private GameObject pauseLayer;
    private int typeBtn;
    
    [SerializeField] private Button btnRestart;
    [SerializeField] private ButtonPause btnPause;
    public event Action<int> OnPushStart;
    public event Action OnPushRestart;
    private void Awake()
    {
        btnPause.ValueChanged += OnPauseClicked;
    }
    public void Init()
    {
        SubscribeButtonsPush();
    }

    public void ShowMenu()
    {
        menuPanel.Show();
        counter.FerstStart();
        rightPanel.SetActiveFalce();
    }

    public void StartButtonPush(int typeBtn)
    {
        OnPushStart?.Invoke(typeBtn);
        menuPanel.Hide();
        rightPanel.SetActive();
        btnRestart.onClick.AddListener(() => RestartButtonPush());
    }
    public void ButtonPush(int typeBtn)
    {
        OnPushStart?.Invoke(typeBtn);
        ButtonBush();
    }

    private void ButtonBush()
    {
        menuPanel.Hide();
        rightPanel.SetActive();
        btnRestart.onClick.AddListener(() => RestartButtonPush());
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

    private void SubscribeButtonsPush()
    {
        var btnStart = menuPanel.GetBtnStart();
        btnStart.onClick.AddListener(() => StartButtonPush((int)TypeButtonStart.Random));
        var btnBlue = menuPanel.GetBtnBlue();
        btnBlue.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Blue));
        var btnYellow = menuPanel.GetBtnYellow();
        btnYellow.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Yellow));
        var btnGreen = menuPanel.GetBtnGreen();
        btnGreen.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Green));
        var btnPink = menuPanel.GetBtnPink();
        btnPink.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Pink));
        var btnRed = menuPanel.GetBtnRed();
        btnRed.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Red));
    }
}