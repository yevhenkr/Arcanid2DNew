
public interface ISystemSave
{
    void Save(string countBlock, float time);

    BestScoreStruct Load(string countBlock, float currentTime);

}
