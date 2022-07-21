using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CounterPanel counter;
    public event Action OnPushStart;

[SerializeField] GameObject _buttonStart;

public void ShowStartMenuButtons()
{
        _buttonStart.SetActive(true);
        counter.FerstStart();
    }

public void PushStartButton()
{
    OnPushStart?.Invoke();
    _buttonStart.active = false;
}
    public void CounterAddOne()
    {
        counter.AddedCount();
    }
}
