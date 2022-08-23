using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button buttonOK;
    [SerializeField] private PanelTheBestScore tePanelTheBestScore;
    /// <summary>
    /// ///////////
    /// </summary>
    /// ////
    private void Start()
    {
        buttonOK.onClick.AddListener(() => SetIsActive(false));
    }

    public void SetIsActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void ShowScoreBestPanel(BestScoreStruct bestScoreStruct)
    {
        tePanelTheBestScore.ShowScore(bestScoreStruct);
    }
}