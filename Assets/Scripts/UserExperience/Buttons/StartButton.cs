using UserExperience;

public class StartButton : Button
{
    public override void Route()
    {
        LevelsManager.LoadGame();
    }
}
