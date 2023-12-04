
using UserExperience;

public class QuitButton : Button
{
    public override void Route()
    {
        LevelsManager.QuitGame();
    }
}