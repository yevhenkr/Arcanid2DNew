using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PoolBlocks blocksController;
    [SerializeField] private RacketController racketController;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BottomBoard bottomBoard;

    private void Start()
    {
        uiManager.OnPushStart += CreateLevelOne;
        bottomBoard.OnBallTouchBottom += GameEnd;
        uiManager.ShowMenu();
        blocksController.EventBallDestroyBlock += BallTouchBlock;
    }

    private void CreateLevelOne()
    {
        racketController.SpawnBall();
        racketController.SpawnPlatform();
        blocksController.InitBlocks();
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