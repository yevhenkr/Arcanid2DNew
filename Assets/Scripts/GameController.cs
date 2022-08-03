 using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PoolBlocks blocksController;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BottomBoard bottomBoard;
    [SerializeField] private WinPanel winPanel;
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

    private void CreateLevelOne()
    {
        playerSpawner.SpawnBall();
        playerSpawner.SpawnPlatform();
        blocksController.ShowBlocks();
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
        GameEnd();
        winPanel.SetIsActive(true);
        //saveScore.SetFloat();
    }
}