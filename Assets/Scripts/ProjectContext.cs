using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public PauseManager PauseManager { get; private set;}//Пауза очень глобальная вещь и многие модули
                                                         //в ней нуждаются по этому они сингл тон
    public static ProjectContext Instance { get; private set; } 
    private void Awake()
    {
        Instance = this;
    }

    public void Initialize()
    {
        PauseManager = new PauseManager();
    }
}
