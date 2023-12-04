using UserExperience;

public class MenuButton : Button
{
    public override void Route()
    {
        LevelsManager.LoadMainMenu();
    }
}