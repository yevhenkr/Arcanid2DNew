using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject rightPanel;
    [SerializeField] private CounterPanel counter;
    public event Action OnPushStart;


    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        counter.FerstStart();
        ShowHideRithPanel();
    }

    public void PushStartButton()
    {
        OnPushStart?.Invoke();
        menuPanel.SetActive(false);
        ShowHideRithPanel();
    }

    public void CounterAddOne()
    {
        counter.AddedCount();
    }
    
     public void ShowHideRithPanel()
     {
         bool isActiv = rightPanel.active;
        rightPanel.SetActive(!isActiv);
    }
    
    
}