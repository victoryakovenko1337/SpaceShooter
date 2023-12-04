using UserExperience;

public class SettingsButton : Button
{
    public override void Route()
    {
        LevelsManager.Settings();
    }
}