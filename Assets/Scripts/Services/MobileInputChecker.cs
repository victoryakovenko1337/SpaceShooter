using UnityEngine;

public class MobileInputChecker : MonoBehaviour
{
    [SerializeField] private GameObject _touchArea;
    private void Awake()
    {
        if (AllServices.Container.Single<IInputService>().GetType() == typeof(MobileInputService))
            _touchArea.SetActive(true);
        else
            _touchArea.SetActive(false);
    }
}
