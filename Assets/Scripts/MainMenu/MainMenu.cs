using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SaveTypeGame playerPrefSave;
    [SerializeField] private MineMenuButtonPanel menuPanel;
    [SerializeField] private SceneLoader sceneLoader;
    void Start()
    {
        playerPrefSave = new SaveTypeGame();
        menuPanel.Init();
        menuPanel.OnPushStart += LoadGame;
    }

    private void LoadGame(int typeBlock)
    {
        playerPrefSave.Save((float)typeBlock);
        SceneManager.LoadScene("Arcanoid");
    }
}