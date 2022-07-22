using Pools;
using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private BlocksController blocksController;
  [SerializeField] private RacketController racketController;
  [SerializeField] private UIManager uiManager;
  [SerializeField] private BottomBoard bottomBoard;

  private void Start()
  {
    uiManager.OnPushStart += CreateLevelOne;
    racketController.BallTouchedBlock += BallTouchBlock;
    bottomBoard.OnBallTouchBottom += GameEnd;
    uiManager.ShowMenu();
  }

  private void CreateLevelOne()
  {
    racketController.SpawnBall();
    racketController.SpawnPlatform();
    blocksController.GenerationBlocks();
  }

   private void BallTouchBlock()
    {
        uiManager.CounterAddOne();
    }

   private void GameEnd()
   {
       uiManager.ShowMenu();
       racketController.DestroyRacket();
        blocksController.AllBlocksToPool();
       print("Game end");
   }
}
