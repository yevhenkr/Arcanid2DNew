using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private BlocksController blocksController;
  [SerializeField] private PlayerSpawner objectSpawner;
  [SerializeField] private UIManager uiManager;
  [SerializeField] private BottomBoard bottomBoard;

  private void Start()
  {
    uiManager.OnPushStart += CreateLevelOne;
    objectSpawner.BallTouchedBlock += BallTouchBlock;
    bottomBoard.OnBallTouchBottom += GameEnd;
    uiManager.ShowStartMenuButtons();
  }

  private void CreateLevelOne()
  {
    objectSpawner.SpawnBall();
    objectSpawner.SpawnPlatform();
    blocksController.GenerationBlocks();
  }

   private void BallTouchBlock()
    {
        uiManager.CounterAddOne();
    }

   private void GameEnd()
   {
       print("Game end");
   }
}
