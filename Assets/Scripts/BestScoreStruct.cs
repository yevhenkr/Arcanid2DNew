public struct BestScoreStruct
{
    private int countBlock;
    private float yourTime;
    private float bestTime;

    public int CountBlock => countBlock;
    public float YourTime => yourTime;
    public float BestTime => bestTime;

    public BestScoreStruct(int countBlock, float yourTime, float bestTime)
    {
        this.countBlock = countBlock;
        this.yourTime = yourTime;
        this.bestTime = bestTime;
    }
}