using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    private SaveTypeGame playerPrefSave;
    [SerializeField] private MenuPanel menuPanel;
    void Start()
    {
        playerPrefSave = new SaveTypeGame();
        menuPanel.Init();
        menuPanel.OnPushStart += SaveTypeBlock;
        playerPrefSave = new SaveTypeGame();
    }

    private void SaveTypeBlock(int typeBlock)
    {
        playerPrefSave.Save((float)typeBlock);
        SceneManager.LoadScene("Arcanoid");
    }
}
