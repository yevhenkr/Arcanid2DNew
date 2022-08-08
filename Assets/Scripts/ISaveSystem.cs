
public interface ISystemSave
{
    void SetBestScore(string countBlock, float time);

    BestScoreStruct GetBestScoreStruct(string countBlock, float currentTime);

}
