using UnityEngine;

public class RightPanel : MonoBehaviour
{
    [SerializeField] private Timer timer;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        timer.ResetTimer();
        this.gameObject.SetActive(false);
    }

    public float GetTime()
    {
        return timer.timeRemaining;
    }
}