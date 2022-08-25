using System;
using UnityEngine;
using UnityEngine.UI;

public enum TypeButtonStart: int
{
    Blue,
    Yellow,
    Green,
    Pink,
    Red,
    Random
}
public class MineMenuButtonPanel : MonoBehaviour
{
    [SerializeField]private Button btnStart;
    [SerializeField]private Button btnBlue;
    [SerializeField]private Button btnYellow;
    [SerializeField]private Button btnGreen;
    [SerializeField]private Button btnPink;
    [SerializeField]private Button btnRed;
    public event Action<int> OnPushStart;

    public void Init()
    {
        SubscribeButtonsPush();
    }

    private void SubscribeButtonsPush()
    {
        btnStart.onClick.AddListener(() => StartButtonPush((int)TypeButtonStart.Random));
        btnBlue.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Blue));
        btnYellow.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Yellow));
        btnGreen.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Green));
        btnPink.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Pink));
        btnRed.onClick.AddListener(() => ButtonPush((int)TypeButtonStart.Red));
    }
    public void StartButtonPush(int typeBtn)
    {
        OnPushStart?.Invoke(typeBtn);
    }
    public void ButtonPush(int typeBtn)
    {
        OnPushStart?.Invoke(typeBtn);
    }
}
