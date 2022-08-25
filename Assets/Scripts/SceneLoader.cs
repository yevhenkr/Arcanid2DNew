using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        string nameCurrentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nameCurrentScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MineMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Arcanoid");
    }
}
