using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PoolBlocks blocksController;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BottomBoard bottomBoard;
    [SerializeField] private SaveScore saveScore;

    private void Start()
    {
        uiManager.Init();
        uiManager.OnPushStart += CreateLevelOne;
        uiManager.OnPushRestart += GameEnd;
        uiManager.ShowMenu();
        blocksController.Init();
        blocksController.EventBallDestroyBlock += BallTouchBlock;
        blocksController.AllBlocksDestroy += GameWin;
        bottomBoard.EventBallIsTouchButtom += GameEnd;
    }

    private void CreateLevelOne(int typeBlock)
    {
        playerSpawner.SpawnBall();
        playerSpawner.SpawnPlatform();
        blocksController.ShowBlocks(typeBlock);
    }

    private void BallTouchBlock()
    {
        uiManager.CounterAddOne();
    }

    private void GameEnd()
    {
        uiManager.ShowMenu();
        playerSpawner.DestroyRacket();
        playerSpawner.DestroyBall();
        blocksController.HideAllObjectsToPool();
    }

    private void GameWin()
    {
        BestScoreStruct bestScoreStruct =
            saveScore.GetBestScoreStruct(blocksController.DestroyBlock.ToString(), uiManager.GetTime());
        saveScore.SetBestScore(blocksController.DestroyBlock.ToString(), uiManager.GetTime());
        GameEnd();
        uiManager.ShowWinPanel(bestScoreStruct);
    }
}