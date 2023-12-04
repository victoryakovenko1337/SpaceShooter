using System.Runtime.InteropServices;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobileFromJS();

    private void Awake()
    {
        RegisterServices();
    }

    private void RegisterServices()
    {
        AllServices.Container.RegisterSingle<IInputService>(InputService());
        AllServices.Container.RegisterSingle<Bounds>(new Bounds());

        LevelsManager.LoadMainMenu();
    }

    private IInputService InputService()
    {
        if (IsMobile())
        {
            return new MobileInputService();
        }
        else
        {
            return new StandaloneInputService();
        }
    }

    public bool IsMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobileFromJS();
#endif
        return false;
    }
}
