using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private PoolBlocks blocksController;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BottomBoard bottomBoard;

    private ISystemSave<BestScoreStruct> playerPrefSaveScore;
    private SaveTypeGame playerPrefSave;
    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Start()
    {
        playerPrefSave = new SaveTypeGame();
        ProjectContext.Instance.Initialize();
        ProjectContext.Instance.PauseManager.Register(this);
        playerPrefSaveScore = new PlayerPrefSave();
        uiManager.OnPushRestart += GameRestart;
        uiManager.ShowMenu();
        uiManager.Init();
        blocksController.Init();
        CreateLevelOne(playerPrefSave.Load("typeBlock"));
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

        SceneManager.LoadScene("Arcanoid");
    }

    private void GameRestart()
    {
        uiManager.ShowMenu();
        playerSpawner.DestroyRacket();
        playerSpawner.DestroyBall();
        blocksController.HideAllObjectsToPool();
    }
    private void GameWin()
    {
        BestScoreStruct bestScoreStruct =
            playerPrefSaveScore.Load(blocksController.DestroyBlock.ToString(),uiManager.GetTime());
        playerPrefSaveScore.Save(uiManager.GetTime(), blocksController.DestroyBlock.ToString());
        GameEnd();
        uiManager.ShowWinPanel(bestScoreStruct);
    }

    void IPauseHandler.SetPaused(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
    }
}