using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour  
{    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }

    public void LoadGame()
    {        
        SceneManager.LoadScene((int)Scenes.Game);
    }

    public void Settings()
    {        
        SceneManager.LoadScene((int)Scenes.Settings);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
