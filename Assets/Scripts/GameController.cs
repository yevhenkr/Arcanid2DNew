 using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PoolBlocks blocksController;
    [SerializeField] private RacketController racketController;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BottomBoard bottomBoard;

    private void Start()
    {
        uiManager.Init();
        uiManager.OnPushStart += CreateLevelOne;
        uiManager.OnPushRestart += GameEnd;
        racketController.OnGameLose += GameEnd;
        uiManager.ShowMenu();
        blocksController.Init();
        blocksController.EventBallDestroyBlock += BallTouchBlock;
    }

    private void CreateLevelOne()
    {
        racketController.SpawnBall();
        racketController.SpawnPlatform();
        blocksController.ShowBlocks();
    }

    private void BallTouchBlock()
    {
        uiManager.CounterAddOne();
    }

    private void GameEnd()
    {
        uiManager.ShowMenu();
        racketController.DestroyRacket();
        blocksController.HideAllObjectsToPool();
    }
}