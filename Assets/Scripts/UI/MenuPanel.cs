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
public class MenuPanel : MonoBehaviour
{
    [SerializeField]private Button btnStart;
    [SerializeField]private Button btnBlue;
    [SerializeField]private Button btnYellow;
    [SerializeField]private Button btnGreen;
    [SerializeField]private Button btnPink;
    [SerializeField]private Button btnRed;

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public Button GetBtnStart()
    {
        return btnStart;
    }
    public Button GetBtnBlue()
    {
        return btnBlue;
    }
    public Button GetBtnYellow()
    {
        return btnYellow;
    }
    public Button GetBtnGreen()
    {
        return btnGreen;
    }
    public Button GetBtnPink()
    {
        return btnPink;
    }
    public Button GetBtnRed()
    {
        return btnRed;
    }
    
}
