using UnityEngine;
using UnityEngine.UI;

public class PanelTheBestScore : MonoBehaviour
{
    public Text countBlocks;
    public Text yourTime;
    public Text theBestTime;

    public void ShowScore(BestScoreStruct bestScoreStruct)
    {
        countBlocks.text = bestScoreStruct.CountBlock.ToString();

        float minutes = Mathf.FloorToInt(bestScoreStruct.YourTime / 60);
        float seconds = Mathf.FloorToInt(bestScoreStruct.YourTime % 60);
        this.yourTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        minutes = Mathf.FloorToInt(bestScoreStruct.BestTime / 60);
        seconds = Mathf.FloorToInt(bestScoreStruct.BestTime % 60);
        this.theBestTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}