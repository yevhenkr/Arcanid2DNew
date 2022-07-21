using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private BlocksController _blocksController;
  [SerializeField] private PlayerSpawner _objectSpawner;
  [SerializeField] private UIManager _uiManager;

  private void Start()
  {
    _uiManager.OnPushStart += CreateLevelOne;
    _objectSpawner.BallTouchedBlock += BallTouchBlock;
    _uiManager.ShowStartMenuButtons();
  }

  private void CreateLevelOne()
  {
    _objectSpawner.SpawnBall();
    _objectSpawner.SpawnPlatform();
    _blocksController.GenerationBlocks();
  }

   private void BallTouchBlock()
    {
        _uiManager.CounterAddOne();
    }
}
