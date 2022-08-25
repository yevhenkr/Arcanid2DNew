using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    private SaveTypeGame playerPrefSave;
    [SerializeField] private MenuPanel menuPanel;
    [SerializeField] private SceneLoader sceneLoader;
    void Start()
    {
        playerPrefSave = new SaveTypeGame();
        menuPanel.Init();
        menuPanel.OnPushStart += LoadGame;
        playerPrefSave = new SaveTypeGame();
    }

    private void LoadGame(int typeBlock)
    {
        playerPrefSave.Save((float)typeBlock);
        SceneManager.LoadScene("Arcanoid");
    }
}