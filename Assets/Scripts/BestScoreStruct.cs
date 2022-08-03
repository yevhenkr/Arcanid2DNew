public struct BestScoreStruct
{
    public int countBlock { get; private set; }
    public float yourTime { get; private set; }
    public float bestTime { get; private set; }

    public BestScoreStruct(int countBlock, float yourTime, float bestTime)
    {
        this.countBlock = countBlock;
        this.yourTime = yourTime;
        this.bestTime = bestTime;
    }
}
