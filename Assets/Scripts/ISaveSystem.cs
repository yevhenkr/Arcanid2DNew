public interface ISystemSave<T>
{
    void Save(float time,string countBlock);

    T Load(string countBlock, float currentTime);
}
