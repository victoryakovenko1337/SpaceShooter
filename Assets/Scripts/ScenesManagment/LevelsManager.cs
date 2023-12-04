using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelsManager  
{    
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
    }

    public static void LoadGame()
    {        
        SceneManager.LoadScene(Scenes.Game);
    }

    public static void Settings()
    {        
        SceneManager.LoadScene(Scenes.Settings);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
