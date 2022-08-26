using UnityEngine;

public class GameController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private PoolBlocks blocksController;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BottomBoard bottomBoard;
    [SerializeField] private SceneLoader sceneLoader;

    private ISystemSave<BestScoreStruct> playerPrefSaveScore;
    private SaveTypeGame saveTypeGame;
    private SaveCountBlock saveCount;

    private void Start()
    {
        saveTypeGame = new SaveTypeGame();
        saveCount = new SaveCountBlock();
        ProjectContext.Instance.Initialize();
        ProjectContext.Instance.PauseManager.Register(this);
        playerPrefSaveScore = new PlayerPrefSave();
        uiManager.OnPushRestart += GameRestart;
        uiManager.OnPushMainMenu += GameEnd;
        uiManager.ShowMenu();
        blocksController.Init();
        CreateLevelOne(saveTypeGame.Load("typeBlock"));
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
        sceneLoader.LoadMainMenu();
    }

    private void GameRestart()
    {
        sceneLoader.RestartCurrentScene();
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